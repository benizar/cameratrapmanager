/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 18:22
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Resources;
using CameratrapManager_lib.ImageProcessing;
using CameratrapManager_lib.Utilities;
using CameratrapManager_lib.CameratrapModel;

namespace CameratrapManager_db
{

	/// <summary>
	/// 
	/// </summary>
	public class ProjectDAO
	{
		
		string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
		
		
		public static void CreateNewProject(Project newProject)
		{
			try {
				string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
				
				using(SQLiteConnection Conn=new SQLiteConnection())
				{
					Conn.ConnectionString = "Data Source="+ projectsPath + @"\\Projects\\" + newProject.Name + ".db;Version=3;New=True;Compress=True;Synchronous=Off";
					Conn.Open();
					
					SQLiteCommand CreateCmd = new SQLiteCommand();
					CreateCmd = Conn.CreateCommand();
					CreateCmd.CommandText = "CREATE TABLE [project] ([id_project] INTEGER  NOT NULL PRIMARY KEY,[project_base64] TEXT NULL)" ;
					CreateCmd.ExecuteNonQuery();
					CreateCmd.CommandText = "CREATE TABLE [images] ( [guid_images] TEXT  NOT NULL PRIMARY KEY, [image_base64] TEXT  NOT NULL)" ;
					CreateCmd.ExecuteNonQuery();
					CreateCmd.Dispose();
					
					
					SQLiteParameter idproject =new SQLiteParameter("@idproject",DbType.Int64){Value= 1};
					SQLiteParameter newproject =new SQLiteParameter("@project",DbType.String){Value= ConversionUtilities.SerializeBase64(newProject)};
					
					
					SQLiteCommand InsertCmd = new SQLiteCommand();
					InsertCmd=Conn.CreateCommand();
					InsertCmd.Parameters.Add(idproject);
					InsertCmd.Parameters.Add(newproject);
					
					
					InsertCmd.CommandText= "INSERT INTO project (id_project, project_base64) VALUES(@idproject, @project)";
					InsertCmd.ExecuteNonQuery();
					InsertCmd.Dispose();
					
				}
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		
		public static Project LoadProject(string existingProject)
		{
			try {
				string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
				Project loadedProj=new Project();
				
				string projectSQL = "SELECT project_base64 FROM project";// WHERE id_project=0"+id_samples.ToString();
				SQLiteConnection projectConn = new SQLiteConnection("Data Source="+ projectsPath + @"\\Projects\\" + existingProject + ".db;Version=3;New=False;Compress=True;Synchronous=Off");
				SQLiteCommand cmd = new SQLiteCommand(projectSQL,projectConn);
				projectConn.Open();
				
				loadedProj = (Project)ConversionUtilities.DeserializeBase64((string)cmd.ExecuteScalar());
				
//				using(SQLiteDataReader sqReader = cmd.ExecuteReader())
//				{
//					if (sqReader.Read())
//					{
//						loadedProj = (Project)ConversionUtilities.DeserializeBase64(sqReader.GetString(0));
//					}
//				}
				
				projectConn.Close();
				
				return loadedProj;
			} catch (Exception ex) {
				throw ex;
			}


		}
		
		public static void RemoveOrphanImages(Project existingProject)
		{
			try {
				string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
				
				using(SQLiteConnection Conn=new SQLiteConnection())
				{
					
					Conn.ConnectionString = "Data Source="+ projectsPath + @"\\Projects\\" + existingProject.Name +".db;New=False;Compress=True;Synchronous=Off";
					Conn.Open();
					
					//Remove unnecesary images from project
					//Get images list
					List<string> existingImages = new List<string>();
					
					SQLiteCommand storedImages=new SQLiteCommand();
					storedImages=Conn.CreateCommand();
					storedImages.CommandText="SELECT * FROM images";
					
					using(SQLiteDataReader dr=storedImages.ExecuteReader())
					{
						while ( dr.Read() )
						{
							existingImages.Add((string)dr["guid_images"]);
							
						}
					}
					
					storedImages.Dispose();
					
					
					//Get remaining images list
					List<string> remainingImages=new List<string>();
					
					foreach(Station st in existingProject.StationsList)
					{
						remainingImages.Add(st.Guid);
						
						foreach(Sample smp in st.SamplesList)
						{
							remainingImages.Add(smp.Guid);
						}
						
					}
					
					
					foreach(string s in existingImages)
					{
						if(remainingImages.Contains(s)==false)
						{
							SQLiteParameter guid =new SQLiteParameter("@guid",DbType.String){Value= s};
							SQLiteCommand DeleteImageCmd=new SQLiteCommand();
							DeleteImageCmd=Conn.CreateCommand();
							DeleteImageCmd.Parameters.Add(guid);
							DeleteImageCmd.CommandText="DELETE FROM images WHERE guid_images = @guid";
							DeleteImageCmd.ExecuteNonQuery();
							DeleteImageCmd.Dispose();
						}
					}
					
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
		
		public static void VacuumProject(string existingProject)
		{
			try {
				string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
				
				using(SQLiteConnection Conn=new SQLiteConnection())
				{
					
					Conn.ConnectionString = "Data Source="+ projectsPath + @"\\Projects\\" + existingProject +".db;New=False;Compress=True;Synchronous=Off";
					Conn.Open();
					
					using (SQLiteCommand vacuum = Conn.CreateCommand())
					{
						vacuum.CommandText = "vacuum;";
						vacuum.ExecuteNonQuery();
					}
				}

				} catch (Exception ex) {
					throw ex;
				}

		}
		
		
		public static void UpdateProject(string oldProjectName, Project updatedProject)
		{
			try {
				string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
				
				using(SQLiteConnection Conn=new SQLiteConnection())
				{
					
					Conn.ConnectionString = "Data Source="+ projectsPath + @"\\Projects\\" + oldProjectName +".db;New=False;Compress=True;Synchronous=Off";
					Conn.Open();
					
					SQLiteCommand DeleteCmd=new SQLiteCommand();
					DeleteCmd=Conn.CreateCommand();
					DeleteCmd.CommandText="DELETE FROM project WHERE id_project=1";
					DeleteCmd.ExecuteNonQuery();
					DeleteCmd.Dispose();
					
					SQLiteParameter idproject =new SQLiteParameter("@idproject",DbType.Int64){Value= 1};
					SQLiteParameter newproject =new SQLiteParameter("@project",DbType.String){Value= ConversionUtilities.SerializeBase64(updatedProject)};
					SQLiteCommand InsertCmd = new SQLiteCommand();
					InsertCmd=Conn.CreateCommand();
					InsertCmd.Parameters.Add(idproject);
					InsertCmd.Parameters.Add(newproject);
					
					InsertCmd.CommandText= "INSERT INTO project (id_project, project_base64) VALUES(@idproject, @project)";
					InsertCmd.ExecuteNonQuery();
					InsertCmd.Dispose();
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		public static Image GetCurrentImage(string project, string guid)
		{
			try {
				string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
				
				string currentPicture="";
				
				using(SQLiteConnection Conn=new SQLiteConnection())
				{
					Conn.ConnectionString="Data Source="+ projectsPath + @"\\Projects\\" + project + ".db;Version=3;New=False;Compress=True;Synchronous=Off";
					Conn.Open();
					
					SQLiteParameter sqlGuid =new SQLiteParameter("@guid",DbType.String){Value= guid};
					SQLiteCommand cmd=new SQLiteCommand();
					cmd=Conn.CreateCommand();
					cmd.Parameters.Add(sqlGuid);
					cmd.CommandText="SELECT image_base64 FROM images WHERE guid_images = @guid";
					
					
					using(SQLiteDataReader sqReader = cmd.ExecuteReader())
					{
						if (sqReader.Read())
						{
							currentPicture =  sqReader.GetString(0);
						}
					}
					
					if(currentPicture=="")
					{
						
						ResourceManager resources = new ResourceManager("CameratrapManager_db.Resources.Images",System.Reflection.Assembly.GetExecutingAssembly());

						
						return ((System.Drawing.Bitmap)(resources.GetObject("no-photo-available")));
						
					}
					else
					{
						return ConversionUtilities.Base64ToImage(currentPicture);
					}
					
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		public static void InsertImage (string currentProjectName, string guid, string imageBase64)
		{
			try {
				string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
				
				using(SQLiteConnection Conn=new SQLiteConnection())
				{
					
					Conn.ConnectionString = "Data Source="+ projectsPath + @"\\Projects\\" + currentProjectName +".db;New=False;Compress=True;Synchronous=Off";
					Conn.Open();
					
					SQLiteParameter sqlGuid= new SQLiteParameter("@guid",DbType.String){Value=guid};
					SQLiteParameter image_base64 = new SQLiteParameter("@image_base64",DbType.String){Value= imageBase64};
					
					
					SQLiteCommand InsertCmd = new SQLiteCommand();
					InsertCmd = Conn.CreateCommand();
					
					
					InsertCmd.Parameters.Add(sqlGuid);
					InsertCmd.Parameters.Add(image_base64);
					
					
					InsertCmd.CommandText = "INSERT INTO images (guid_images, image_base64) VALUES(@guid, @image_base64)";
					InsertCmd.ExecuteNonQuery();
					InsertCmd.Dispose();
					
				}
			} catch (Exception ex) {
				throw ex;
			}

		}
		
		
		
		
	}
	
	
}