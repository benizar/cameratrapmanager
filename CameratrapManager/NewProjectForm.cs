/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 19:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CameratrapManager_lib.CameratrapModel;
using CameratrapManager_db;
using CameratrapManager_lib.DataEntry;
using GeoAPI.Geometries;

namespace CameratrapManager
{
	/// <summary>
	/// Description of NewProjectForm.
	/// </summary>
	public partial class NewProjectForm : Form
	{			
		
		Project _newProjectCreated;
		List<IPolygon> _studyArea;
		
		
		public Project NewProjectCreated {
			get { return _newProjectCreated; }
		}
		
		
		public NewProjectForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtCancelProjectClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void BtCreateProjectClick(object sender, EventArgs e)
		{
			try {
				_newProjectCreated = new Project(txtProjectName.Text,
			                        cmbProjectType.Text,
			                        txtProjectCreator.Text,
			                        txtProjectSubject.Text,
			                        txtProjectDescription.Text,
			                        DateTime.Now,
			                        DateTime.Now,
			                        _studyArea, Convert.ToInt16(txtGridSize.Text));
			
			
				ProjectDAO.CreateNewProject(_newProjectCreated);
				
				this.Close();
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		

		void BtLoadSHPClick(object sender, EventArgs e)
		{
			try {
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
			   	openFileDialog1.Filter = "ESRI Shapefiles|*.shp";
			   	openFileDialog1.Title = "Select a Shapefile";
			
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					this.Text=openFileDialog1.FileName;
					LoadShapefile bounds = new LoadShapefile(openFileDialog1.FileName,"23030");
					_studyArea=bounds.Polygons;
				}
			} catch (Exception ex) {
				throw ex;
			}

		}
		
		
		
	}
}
