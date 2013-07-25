/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 27/05/2011
 * Hora: 13:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using CameratrapManager_lib.CameratrapModel;
using CameratrapManager_lib.CameratrapModel.SampleObservations;
using CameratrapManager_lib.OCR;
using CameratrapManager_db;
using CameratrapManager_lib.ImageProcessing;
using CameratrapManager_lib.Utilities;

namespace CameratrapManager
{
	/// <summary>
	/// Description of NewSamplesForm.
	/// </summary>
	public partial class NewSamplesForm : Form
	{
		
		Project _updatedProject;
		Station _updatedStation;
		
		FolderBrowserDialog selectPicturesFolderDialog=new FolderBrowserDialog();
		DialogResult _folderSelected;
		
		
		public NewSamplesForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public NewSamplesForm(Project currentProject, Station currentStation)
		{
			InitializeComponent();
			_updatedProject=currentProject;
			_updatedStation=currentStation;
			selectPicturesFolderDialog.ShowNewFolderButton = false;
		}
		
		
		public Project UpdatedProject {
			get { return _updatedProject; }
		}
		
		
		
		void BtSelectSamplesFolderClick(object sender, EventArgs e)
		{

			
			_folderSelected=this.selectPicturesFolderDialog.ShowDialog();
			
			if (_folderSelected==DialogResult.OK)
			{
				txtPicturesFolder.Text=selectPicturesFolderDialog.SelectedPath;
			}
			
		}
		
		void BtCreateSamplesClick(object sender, EventArgs e)
		{
			
			if (_folderSelected==DialogResult.OK)
			{
				foreach (string jpg in Directory.GetFiles( Path.GetFullPath(txtPicturesFolder.Text),"*.jpg"))
		    	{
					Sample nextSample = new Sample(_updatedStation.Lat, _updatedStation.Lon, jpg);
					
					//OCR template for presure in inHg
					OCR_Template ocrPres=new OCR_Template("ocrPres","Moultrie Game Camera",
					                                      new Rectangle(71,2018,225,96),new Size(2848,2136));
					//OCR template for temp in ºC
					OCR_Template ocrTemp=new OCR_Template("ocrTemp","Moultrie Game Camera",
					                                      new Rectangle(847,2024,196,111),new Size(2848,2136));
					nextSample.OCR_Observations_list.Add(new DoubleObservation("Pressure (inHg)","",ocrPres));
					nextSample.OCR_Observations_list.Add(new IntegerObservation("Temperature (ºC)","",ocrTemp));
					nextSample.Species_Observations_list.Add(new SpeciesObservation("Species","Pending",0));
					
					nextSample.RunOCR(nextSample.OCR_Observations_list);
					
					Image nextImage = Image.FromFile(jpg);
					
					foreach(Station st in _updatedProject.StationsList)
					{
						if(st.Guid==_updatedStation.Guid)
						{
							st.SamplesList.Add(nextSample);
						}
					}
					
					ProjectDAO.InsertImage(_updatedProject.Name, nextSample.Guid, ConversionUtilities.ImageToBase64(nextImage, System.Drawing.Imaging.ImageFormat.Jpeg));
					
				}
				
					ProjectDAO.UpdateProject(_updatedProject.Name,_updatedProject);

			}
			
			
			
			
		}
	}
}
