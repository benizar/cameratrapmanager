/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 25/05/2011
 * Hora: 14:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using CameratrapManager_lib.CameratrapModel;
using CameratrapManager_db;
using CameratrapManager.Utilities;
using GeoAPI.Geometries;

namespace CameratrapManager
{
	/// <summary>
	/// Description of NewStationForm.
	/// </summary>
	public partial class NewStationForm : Form
	{
		Project _updatedProject;
		Station _newStationCreated;
		
		OpenFileDialog selectMainPictureDialog = new OpenFileDialog();
		DialogResult _pictureSelected;
		
		
		
		
		public Project UpdatedProject {
			get { return _updatedProject; }
		}
		
//		public Station NewStationCreated {
//			get { return _newStationCreated; }
//		}
		
		
		
		public NewStationForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		
		public NewStationForm(Project currentProject)
		{
			
			InitializeComponent();
			
			_updatedProject=currentProject;
			selectMainPictureDialog.Filter = "Jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*"; 
   			selectMainPictureDialog.Title = "Select the main picture";

		}
		
		
		void BtCreateStationClick(object sender, EventArgs e)
		{
			try {
				if(_pictureSelected== DialogResult.OK)
				{
					GisSharpBlog.NetTopologySuite.IO.WKTReader wkt=new GisSharpBlog.NetTopologySuite.IO.WKTReader();
					IPolygon grd = (IPolygon)wkt.Read(txtWKT.Text);
					
					_newStationCreated=new Station(txtStationID.Text, grd, txtMainPicture.Text);
					_newStationCreated.SamplesList=new System.Collections.Generic.List<Sample>();
					
					_updatedProject.StationsList.Add(_newStationCreated);
					
					this.Close();
				}
				else
				{
					MessageBox.Show("You must select at least one main picture to create a Station");
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		void BtCancelStationClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
		void BtSelectMainPictureClick(object sender, EventArgs e)
		{
			
			_pictureSelected = selectMainPictureDialog.ShowDialog();
			
			if (_pictureSelected==DialogResult.OK)
			{
				txtMainPicture.Text = selectMainPictureDialog.FileName;
			}
		}
	}
}
