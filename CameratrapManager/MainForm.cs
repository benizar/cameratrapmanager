//Camera Trap Manager. A C# desktop application for managing
//camera trap pictures and creating some reports (Excel, GIS, PDF, etc).
//Copyright (C) 2015 Benito M. Zaragozí
//Authors: Benito M. Zaragozí (www.gisandchips.org)
//Send comments and suggestions to benito.zaragozi@ua.es
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with this program. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Core.ImageProcessing;
using CameratrapManager.Model;
using CameratrapManager.OCR;
using CameratrapManager.Model.SampleObservations;
using Core.Carto;
using CameratrapManager.DAO;
using CameratrapManager.Output;
using Core.Analysis;


namespace CameratrapManager
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		DataTable speciesList=new DataTable();
		
		Project _currentProject = null;
		Station _currentStation = null;
		Sample _currentSample = null;
		
		string projectsPath = System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location)+ @"\\Projects\\";
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		

		#region Program Set Up
		
		void MainFormLoad(object sender, EventArgs e)
		{
			try {
				speciesList.Columns.Add("Target Species", typeof(string));
				
				cmbSelectSpecies.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
				cmbSelectSpecies.AutoCompleteSource = AutoCompleteSource.CustomSource;
				
				DataTable table = new DataTable();
				table.Columns.Add("1", typeof(int));
				table.Columns.Add("2", typeof(int));
				table.Columns.Add("3", typeof(int));
				table.Columns.Add("4", typeof(int));
				
				table.Rows.Add(1, 2, 3, 4);
				table.Rows.Add(5, 6, 7, 8);
				table.Rows.Add(9, 10, 11, 12);
				table.Rows.Add(13, 14, 15, 0);
				
				dgvSelectCount.DataSource=table;
				foreach (DataGridViewColumn c in dgvSelectCount.Columns)
				{
					c.Width=50;
				}
				
				cmsTreeView.Enabled=false;
				btEmpty.Enabled=false;
				btInvalid.Enabled=false;
				btManagement.Enabled=false;
				btUnknown.Enabled=false;
				
				cmbSelectSpecies.Enabled=false;
				
				saveProjectToolStripMenuItem.Enabled=false;
				closeProjectToolStripMenuItem.Enabled=false;
				
				cameraStationsToolStripMenuItem.Enabled=false;
				photoSamplesToolStripMenuItem.Enabled=false;
				reportsToolStripMenuItem.Enabled=false;
				
				
			}
			catch (Exception ex)
			{
				throw(ex);
			}

		}
		
		void EnableButtons()
		{
			cmsTreeView.Enabled=true;
			btEmpty.Enabled=true;
			btInvalid.Enabled=true;
			btManagement.Enabled=true;
			btUnknown.Enabled=true;
			
			cmbSelectSpecies.Enabled=true;
			
			saveProjectToolStripMenuItem.Enabled=true;
			closeProjectToolStripMenuItem.Enabled=true;
			
			cameraStationsToolStripMenuItem.Enabled=true;
			photoSamplesToolStripMenuItem.Enabled=true;
			reportsToolStripMenuItem.Enabled=true;
		}
		
		#endregion

		#region Create New or Open Existing Project
		
		void NewProjectToolStripMenuItemClick(object sender, EventArgs e)
		{
			
			try {
				
				NewProjectForm newProjForm=new NewProjectForm();

				if  (newProjForm.ShowDialog()== DialogResult.OK)
				{
					if(newProjForm.isCreated)
					{
						_currentProject=newProjForm.NewProjectCreated;
						refreshSpeciesList(_currentProject);
						PopulateTree();
						EnableButtons();
					}
//					_currentProject.SpeciesList.Add("Empty Picture");
//					_currentProject.SpeciesList.Add("Invalid Picture");
//					_currentProject.SpeciesList.Add("Management");
//					_currentProject.SpeciesList.Add("Unknown");
					
					
				}
				
			} catch (Exception ex)
			{
				throw ex;
			}
			
			
		}
		
		void ExistingProjectToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				OpenFileDialog openProjectDialog = new OpenFileDialog();
				openProjectDialog.Filter = "Cameratrap projects (*.db)|*.db|All files (*.*)|*.*";
				openProjectDialog.InitialDirectory = projectsPath;
				openProjectDialog.Title = "Open a existing project";
				
				if( openProjectDialog.ShowDialog() == DialogResult.OK )
				{
					_currentProject = ProjectDAO.LoadProject(Path.GetFileNameWithoutExtension(openProjectDialog.FileName));
					
					refreshSpeciesList(_currentProject);
					
					PopulateTree();
					
					EnableButtons();
					
//					ProjectDAO.VacuumProject(_currentProject.Name);
					
				}
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		
		#endregion
		
		#region Save Project
		
		void SaveProjectToolStripMenuItemClick(object sender, EventArgs e)
		{
			_currentProject.CompletionDate=DateTime.Now;
			ProjectDAO.UpdateProject(_currentProject.Name,_currentProject);
			ProjectDAO.RemoveOrphanImages(_currentProject);
		}
		
		#endregion
		
		#region Create Station
		
		void NewStationToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(_currentProject!=null)
			{
				NewStationForm newStatForm = new NewStationForm(_currentProject);
				if (newStatForm.ShowDialog()==DialogResult.OK)
				{
					_currentProject=newStatForm.UpdatedProject;
					ProjectDAO.UpdateProject(_currentProject.Name,_currentProject);
					
					PopulateTree();
				}
			}
			else
			{
				MessageBox.Show("There is no current project");
			}

		}
		
		#endregion
		
		#region Select Station Image
		
		void TsbSelectStationImageClick(object sender, EventArgs e)
		{
			SelectStationImage();
		}
		
		void CtxtsbSelectStationImageClick(object sender, EventArgs e)
		{
			SelectStationImage();
		}
		
		
		
		void SelectStationImage()
		{
			try {

				if(tvProject.SelectedNode.Tag.GetType()==_currentStation.GetType())
				{
					OpenFileDialog selectMainPictureDialog = new OpenFileDialog();
					selectMainPictureDialog.Filter = "Jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
					selectMainPictureDialog.Title = "Select the main picture";
					
					if(selectMainPictureDialog.ShowDialog() == DialogResult.OK)
					{
						
						using (FileStream stream = new FileStream(selectMainPictureDialog.FileName, FileMode.Open, FileAccess.Read))
						{
							
							ProjectDAO.InsertImage(_currentProject.Name, _currentStation.Guid, ConversionUtilities.ImageToBase64(Main_processing.ResizeImage(Image.FromStream(stream)), System.Drawing.Imaging.ImageFormat.Jpeg));
						}
						
						_currentStation.MetadataFromImage(selectMainPictureDialog.FileName);
						
						pictureBox1.Image= CameratrapManager.DAO.ProjectDAO.GetCurrentImage(_currentProject.Name,_currentStation.Guid);
						
						ProjectDAO.UpdateProject(_currentProject.Name,_currentProject);
						
						
						//Must solve the update node after select station image
//	   					UpdateCurrentNodeTree();
						refreshViewData(_currentStation);
						
						
					}
					else
					{
						MessageBox.Show("You must select a Station node");
					}
				}
				
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		#endregion
		
		#region Remove Station
		void tsbRemoveStationClick(object sender, EventArgs e)
		{
			RemoveStation();
		}

		void CtxtsbRemoveStationClick(object sender, EventArgs e)
		{
			RemoveStation();
		}
		
		void RemoveStation()
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType()==_currentStation.GetType())
				{
					_currentProject.StationsList.Remove((Station)tvProject.SelectedNode.Tag);
					PopulateTree();
				}
				else
				{
					MessageBox.Show("You must select the Station node that you want to remove");
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		#endregion
		
		#region Upload Samples
		
		void tsbUploadSamplesClick(object sender, EventArgs e)
		{
			if(_currentStation.MainPictureFilename!="Not Provided")
			{
				UploadSamplesToStation();
				_currentProject=ProjectDAO.LoadProject(_currentProject.Name);
				PopulateTree();
			}
			else
			{
				MessageBox.Show("You must load the station main image before upload samples");
			}
			
		}
		
		void cntxttbUploadSamplesClick(object sender, EventArgs e)
		{
			if(_currentStation.MainPictureFilename!="Not Provided")
			{
				UploadSamplesToStation();
				_currentProject=ProjectDAO.LoadProject(_currentProject.Name);
				PopulateTree();
			}
			else
			{
				MessageBox.Show("You must load the station main image before upload samples");
			}
		}
		
		void UploadSamplesToStation()
		{
			try {
				FolderBrowserDialog selectPicturesFolderDialog=new FolderBrowserDialog();
				selectPicturesFolderDialog.ShowNewFolderButton = false;
				if (selectPicturesFolderDialog.ShowDialog()==DialogResult.OK)
				{
					foreach (string jpg in Directory.GetFiles( selectPicturesFolderDialog.SelectedPath,"*.jpg"))
					{
						Sample nextSample = new Sample(_currentStation.Lat, _currentStation.Lon, jpg);
						
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
						
						foreach(Station st in _currentProject.StationsList)
						{
							if(st.Guid==_currentStation.Guid)
							{
								st.SamplesList.Add(nextSample);
							}
						}
						
						ProjectDAO.InsertImage(_currentProject.Name, nextSample.Guid, ConversionUtilities.ImageToBase64(Main_processing.ResizeImage(nextImage), System.Drawing.Imaging.ImageFormat.Jpeg));
						
					}
					
					ProjectDAO.UpdateProject(_currentProject.Name,_currentProject);
					
				}
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		#endregion
		
		#region Remove Sample
		
		void tsbRemoveSampleClick(object sender, EventArgs e)
		{
			RemoveSample();
		}
		
		void CntxtsbRemoveSampleClick(object sender, EventArgs e)
		{
			RemoveSample();
		}
		
		void RemoveSample()
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType()==_currentSample.GetType())
				{
					_currentProject.StationsList[tvProject.SelectedNode.Parent.Index].SamplesList.Remove((Sample)tvProject.SelectedNode.Tag);
					PopulateTree();
				}
				else
				{
					MessageBox.Show("You must select the Sample node that you want to remove");
				}
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		#endregion
		
		#region Interaction with Project
		
		void TvProjectAfterSelect(object sender, TreeViewEventArgs e)
		{

			try {
				if(tvProject.SelectedNode.Tag.GetType() == typeof(Station))
				{
					_currentStation= (Station)tvProject.SelectedNode.Tag;
					pictureBox1.Image= CameratrapManager.DAO.ProjectDAO.GetCurrentImage(_currentProject.Name,_currentStation.Guid);
					
					
					refreshViewData(_currentStation);
				}
				
				else if(tvProject.SelectedNode.Tag.GetType() == typeof(Sample))
				{
					_currentSample=(Sample)tvProject.SelectedNode.Tag;
					_currentStation= (Station)tvProject.SelectedNode.Parent.Tag;
					
					pictureBox1.Image= CameratrapManager.DAO.ProjectDAO.GetCurrentImage(_currentProject.Name,_currentSample.Guid);
					
					refreshViewData(_currentSample);
				}
			} catch (Exception ex) {
				throw ex;
			}
			
			
			
		}
		
		
		void CmbSelectSpeciesKeyDown(object sender, KeyEventArgs e)
		{
			try {
				if(e.KeyCode == Keys.Enter && cmbSelectSpecies.Text!="")
				{
					speciesList.Rows.Add(cmbSelectSpecies.SelectedText);
					_currentProject.SpeciesList.Add(cmbSelectSpecies.SelectedText);
					dgvSelectSpecies.DataSource=speciesList;
					cmbSelectSpecies.Text="";
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		void DgvSelectSpeciesClick(object sender, DataGridViewCellEventArgs e)
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType() == typeof(Sample))
				{
					((SpeciesObservation)_currentSample.Species_Observations_list[0]).Value = dgvSelectSpecies.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
					
					refreshViewData(_currentSample);
					
					tvProject.Focus();
					UpdateCurrentNodeTree();
					
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		void BtManagementClick(object sender, EventArgs e)
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType() == typeof(Sample))
				{
					((SpeciesObservation)_currentSample.Species_Observations_list[0]).Value = "Management";
					
					refreshViewData(_currentSample);
					
					tvProject.Focus();
					UpdateCurrentNodeTree();
					
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
		
		void BtInvalidClick(object sender, EventArgs e)
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType() == typeof(Sample))
				{
					((SpeciesObservation)_currentSample.Species_Observations_list[0]).Value = "Invalid Picture";
					
					refreshViewData(_currentSample);
					
					tvProject.Focus();
					UpdateCurrentNodeTree();
					
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
		
		void BtUnknownClick(object sender, EventArgs e)
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType() == typeof(Sample))
				{
					((SpeciesObservation)_currentSample.Species_Observations_list[0]).Value = "Unknown";
					
					refreshViewData(_currentSample);
					
					tvProject.Focus();
					UpdateCurrentNodeTree();
					
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
		
		void BtEmptyClick(object sender, EventArgs e)
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType() == typeof(Sample))
				{
					((SpeciesObservation)_currentSample.Species_Observations_list[0]).Value = "Empty Picture";
					
					refreshViewData(_currentSample);
					
					tvProject.Focus();
					UpdateCurrentNodeTree();
					
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
		
		void DgvSelectCountClick(object sender, DataGridViewCellEventArgs e)
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType() == typeof(Sample))
				{
					((SpeciesObservation)_currentSample.Species_Observations_list[0]).Count = Convert.ToInt32(dgvSelectCount.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString());
					refreshViewData(_currentSample);

					UpdateCurrentNodeTree();
					tvProject.Focus();
				}
			} catch (Exception ex) {
				throw ex;
			}

		}
		
		void DgvSelectSpeciesUserDeletedRow(object sender, DataGridViewRowEventArgs e)
		{
			try {
				List<string> remainingItems=new List<string>();
				
				foreach(DataGridViewRow dr in dgvSelectSpecies.Rows)
				{
					if((string)dr.Cells[0].Value!=null)
					{
						remainingItems.Add((string)dr.Cells[0].Value);
					}
				}
				
				speciesList.Rows.Clear();
				_currentProject.SpeciesList.Clear();
				
				foreach (string s in remainingItems)
				{
					_currentProject.SpeciesList.Add(s);
					speciesList.Rows.Add(s);
				}
				
				dgvSelectSpecies.DataSource = speciesList;
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		
		//		void TvProjectMouseMove(object sender, MouseEventArgs e)
//		{
//			// Get the node at the current mouse pointer location.
//			TreeNode theNode =  this.tvProject.GetNodeAt(e.X, e.Y);
//
//			// Set a ToolTip only if the mouse pointer is actually paused on a node.
//			if ((theNode != null&&theNode.Tag.GetType()== typeof(Station) ))
//			{
//			   // Verify that the tag property is not "null".
//			   if ((theNode != null&&theNode.Tag.GetType()== typeof(Station) ))
//			   {
//			      // Change the ToolTip only if the pointer moved to a new node.
//			      if (((Station)theNode.Tag).Alt.ToString()!=this.toolTip1.GetToolTip(this.tvProject))
//			      {
//			         this.toolTip1.SetToolTip(this.tvProject, ((Station)theNode.Tag).Alt.ToString());
//			      }
//			   }
//			   else
//			   {
//			      this.toolTip1.SetToolTip(this.tvProject, "");
//			   }
//			}
//			else     // Pointer is not over a node so clear the ToolTip.
//			{
//			   this.toolTip1.SetToolTip(this.tvProject, "");
//			}
//		}
		
		
		#endregion
		
		#region Fill Form with current data
		
		
		private void UpdateCurrentNodeTree()
		{
			try {
				if(tvProject.SelectedNode.Tag.GetType()==typeof(Station))
				{
					switch (((Station)tvProject.SelectedNode.Tag).MainPictureFilename!="Not Provided" && ((Station)tvProject.SelectedNode.Tag).Alt!=0 &&((Station)tvProject.SelectedNode.Tag).Compass!=0 && ((Station)tvProject.SelectedNode.Tag).Lat!=0 && ((Station)tvProject.SelectedNode.Tag).Lon!=0) {
						case true:
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 6;
							break;
						default:
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 2;
							break;
					}
					
				}
				else if(tvProject.SelectedNode.Tag.GetType()==typeof(Sample))
				{
					
					switch (((Sample)tvProject.SelectedNode.Tag).Species_Observations_list[0].Value) {
						case "Pending":
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 2;
							break;
							
						case "Unknown":
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 4;
							break;
						case "Invalid Picture":
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 3;
							break;
						case "Empty Picture":
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 5;
							break;
						case "Management":
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 6;
							break;
						default:
							tvProject.SelectedNode.ImageIndex = tvProject.SelectedNode.SelectedImageIndex = 1;
							break;
					}
				}
			} catch (Exception ex) {
				throw ex;
			}
			

		}
		
		private void PopulateTree()
		{
			try {
				tvProject.Nodes.Clear();
				TreeNode firstNode=tvProject.Nodes.Add(_currentProject.Name,_currentProject.Name,0);
				firstNode.Tag = _currentProject;
				
				if(_currentProject.StationsList.Count>0)
				{
					int id_station=1;
					foreach(Station st in _currentProject.StationsList)
					{
						TreeNode secondNode=new TreeNode();
						
						
						switch (st.MainPictureFilename!="Not Provided" && st.Alt!=0 &&st.Compass!=0 && st.Lat!=0 && st.Lon!=0) {
							case true:
								
								secondNode=firstNode.Nodes.Add("Station "+st.StationID,"Station "+st.StationID,1);
								secondNode.Tag=st;
								
								secondNode.ImageIndex = secondNode.SelectedImageIndex = 6;
								
								id_station++;
								break;
							default:
								secondNode=firstNode.Nodes.Add("Station "+st.StationID,"Station "+st.StationID,2);
								secondNode.Tag=st;
								
								secondNode.ImageIndex = secondNode.SelectedImageIndex = 2;
								
								id_station++;
								break;
						}
						
						
						
						if (st.SamplesList.Count>0)
						{
							int id_sample=1;
							foreach(Sample smpl in st.SamplesList)
							{
								TreeNode thirdNode=new TreeNode();
								
								switch (((SpeciesObservation)smpl.Species_Observations_list[0]).Value) {
									case "Pending":
										thirdNode = secondNode.Nodes.Add("Sample "+id_sample.ToString(),"Sample "+id_sample.ToString(),2);
										thirdNode.Tag = smpl;
										
										thirdNode.ImageIndex = thirdNode.SelectedImageIndex = 2;
										
										id_sample++;
										
										break;
									case "Unknown":
										thirdNode = secondNode.Nodes.Add("Sample "+id_sample.ToString(),"Sample "+id_sample.ToString(),4);
										thirdNode.Tag = smpl;
										
										thirdNode.ImageIndex = thirdNode.SelectedImageIndex = 4;
										
										id_sample++;
										
										break;
									case "Invalid Picture":
										thirdNode = secondNode.Nodes.Add("Sample "+id_sample.ToString(),"Sample "+id_sample.ToString(),3);
										thirdNode.Tag = smpl;
										
										thirdNode.ImageIndex = thirdNode.SelectedImageIndex = 3;
										
										id_sample++;
										
										break;
										
									case "Empty Picture":
										thirdNode = secondNode.Nodes.Add("Sample "+id_sample.ToString(),"Sample "+id_sample.ToString(),5);
										thirdNode.Tag = smpl;
										
										thirdNode.ImageIndex = thirdNode.SelectedImageIndex = 5;
										
										id_sample++;
										
										break;
										
									case "Management":
										thirdNode = secondNode.Nodes.Add("Sample "+id_sample.ToString(),"Sample "+id_sample.ToString(),6);
										thirdNode.Tag = smpl;
										
										thirdNode.ImageIndex = thirdNode.SelectedImageIndex = 6;
										
										id_sample++;
										
										break;
										
									default:
										thirdNode = secondNode.Nodes.Add("Sample "+id_sample.ToString(),"Sample "+id_sample.ToString(),1);
										thirdNode.Tag = smpl;
										
										thirdNode.ImageIndex = thirdNode.SelectedImageIndex = 1;
										
										id_sample++;
										
										break;
								}
							}
						}
					}
					
				}
				tvProject.ExpandAll();
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		private void refreshSpeciesList(Project currentProject)
		{
			try {
				foreach(string s in _currentProject.SpeciesList)
				{
					speciesList.Rows.Add(s);
				}
				dgvSelectSpecies.DataSource=speciesList;
				
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		private void refreshViewData(Station currentStation)
		{
			try {
				//Refresh the listview
				lstViewData.Items.Clear();
				lstViewData.Columns.Clear();
				
				ColumnHeader columnheader;		// Used for creating column headers.
				ListViewItem listviewitem;		// Used for creating listview items.
				
				// Ensure that the view is set to show details.
				lstViewData.View = View.Details;
				
				listviewitem = new ListViewItem("Station ID");
				listviewitem.SubItems.Add(currentStation.StationID);
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Latitude");
				listviewitem.SubItems.Add(currentStation.Lat.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Longitude");
				listviewitem.SubItems.Add(currentStation.Lon.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Altitude");
				listviewitem.SubItems.Add(currentStation.Alt.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Orientation");
				listviewitem.SubItems.Add(currentStation.Compass.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Main Picture Raw Name");
				listviewitem.SubItems.Add(currentStation.MainPictureFilename);
				this.lstViewData.Items.Add(listviewitem);
				
				
				// Create some column headers for the data.
				columnheader = new ColumnHeader();
				columnheader.Text = "Prop";
				this.lstViewData.Columns.Add(columnheader);
				
				columnheader = new ColumnHeader();
				columnheader.Text = "Value";
				this.lstViewData.Columns.Add(columnheader);
				
				// Loop through and size each column header to fit the column header text.
				foreach (ColumnHeader ch in this.lstViewData.Columns)
				{
					ch.Width = -2;
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		private void refreshViewData(Sample currentSample)
		{
			try {
				//Refresh the listview
				lstViewData.Items.Clear();
				lstViewData.Columns.Clear();
				
				ColumnHeader columnheader;		// Used for creating column headers.
				ListViewItem listviewitem;		// Used for creating listview items.
				
				// Ensure that the view is set to show details.
				lstViewData.View = View.Details;
				
				listviewitem = new ListViewItem("Camera Model");
				listviewitem.SubItems.Add(_currentSample.CameraModel);
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Camera Manufacturer");
				listviewitem.SubItems.Add(_currentSample.CameraManufacturer);
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Image Height");
				listviewitem.SubItems.Add(_currentSample.Height.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Image Width");
				listviewitem.SubItems.Add(_currentSample.Width.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Vertical Resolution");
				listviewitem.SubItems.Add(_currentSample.VerticalResolution.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Horizontal Resolution");
				listviewitem.SubItems.Add(_currentSample.HorizontalResolution.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Date");
				listviewitem.SubItems.Add(_currentSample.DateTime.Date.ToShortDateString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Time");
				listviewitem.SubItems.Add(_currentSample.DateTime.TimeOfDay.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Latitude");
				listviewitem.SubItems.Add(_currentSample.Lat.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Longitude");
				listviewitem.SubItems.Add(_currentSample.Lon.ToString());
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Day Or Night");
				listviewitem.SubItems.Add(_currentSample.DayOrNight);
				this.lstViewData.Items.Add(listviewitem);
				
				listviewitem = new ListViewItem("Moon Phase");
				listviewitem.SubItems.Add(_currentSample.MoonPhase);
				this.lstViewData.Items.Add(listviewitem);
				
				
				foreach (Observation obs in _currentSample.OCR_Observations_list)
				{
					listviewitem = new ListViewItem(obs.Name);
					listviewitem.SubItems.Add(obs.Value.ToString());
					this.lstViewData.Items.Add(listviewitem);
				}
				
				foreach (SpeciesObservation obs in _currentSample.Species_Observations_list)
				{
					SpeciesObservation specie = (SpeciesObservation)obs;
					
					listviewitem = new ListViewItem(specie.Name);
					listviewitem.SubItems.Add(specie.Value.ToString());
					listviewitem.Font = new Font(listviewitem.Font, FontStyle.Bold);
					this.lstViewData.Items.Add(listviewitem);
					
					listviewitem = new ListViewItem(specie.Name+ " count");
					listviewitem.SubItems.Add(specie.Count.ToString());
					listviewitem.Font = new Font(listviewitem.Font, FontStyle.Bold);
					this.lstViewData.Items.Add(listviewitem);
				}
				
				
				// Create some column headers for the data.
				columnheader = new ColumnHeader();
				columnheader.Text = "Prop";
				this.lstViewData.Columns.Add(columnheader);
				
				columnheader = new ColumnHeader();
				columnheader.Text = "Value";
				this.lstViewData.Columns.Add(columnheader);
				
				// Loop through and size each column header to fit the column header text.
				foreach (ColumnHeader ch in this.lstViewData.Columns)
				{
					ch.Width = -2;
				}
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		#endregion
		
		#region Reports
		
		
		void tsbCreateAbundanceShapefilesClick(object sender, EventArgs e)
		{
			try {
				SaveFileDialog saveSHP = new SaveFileDialog();
				saveSHP.FileName = _currentProject.Name;
				saveSHP.Filter = "ESRI shapefile |(*.shp*)";
				saveSHP.InitialDirectory = projectsPath;
				
				if (saveSHP.ShowDialog() == DialogResult.OK)
				{
					Abundances_ShpWriter shp=new Abundances_ShpWriter(_currentProject,saveSHP.FileName);
					MessageBox.Show("Shapefiles created!!. You can use your GIS program to open it and perform a convenient layout");
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		void tsbCompletePDFClick(object sender, EventArgs e)
		{
			try {
				SaveFileDialog savePDF = new SaveFileDialog();
				savePDF.FileName = _currentProject.Name;
				savePDF.DefaultExt = "pdf";
				savePDF.Filter = "PDF Portable Document Format |(*.pdf*)";
				savePDF.InitialDirectory = projectsPath;
				
				if (savePDF.ShowDialog() == DialogResult.OK)
				{
					PDFWriter pdf=new PDFWriter(_currentProject,savePDF.FileName);
					MessageBox.Show("Pdf created!!");
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		void tsbExportToExcelClick(object sender, EventArgs e)
		{
			try {
				SaveFileDialog saveXLS = new SaveFileDialog();
				saveXLS.FileName = _currentProject.Name;
				saveXLS.DefaultExt = "xls";
				saveXLS.Filter = "Microsoft Office Excel Workbook |(*.xls*)";
				saveXLS.CheckFileExists = false;
				saveXLS.InitialDirectory = projectsPath;
				
				if (saveXLS.ShowDialog() == DialogResult.OK)
				{
					int totalRows=0;
					FileStream stream = new FileStream(saveXLS.FileName, FileMode.OpenOrCreate);
					ExcelWriter writer = new ExcelWriter(stream);
					writer.BeginWrite();
					
					writer.WriteCell(0, 0, "Station ID");
					writer.WriteCell(0, 1, "Camera Manufacturer");
					writer.WriteCell(0, 2, "Camera Model");
					writer.WriteCell(0, 3, "Image Name");
					writer.WriteCell(0, 4, "Date");
					writer.WriteCell(0, 5, "Time");
					writer.WriteCell(0, 6, "Pressure (inHg)");
					writer.WriteCell(0, 7, "Temperature (Celsius)");
					writer.WriteCell(0, 8, "Species");
					writer.WriteCell(0, 9, "Count");
					
					foreach(Station st in _currentProject.StationsList)
					{
						foreach(Sample smp in st.SamplesList)
						{
							totalRows++;
							writer.WriteCell(totalRows, 0, st.StationID);
							writer.WriteCell(totalRows, 1, smp.CameraManufacturer);
							writer.WriteCell(totalRows, 2, smp.CameraModel);
							writer.WriteCell(totalRows, 3, smp.ImageName);
							writer.WriteCell(totalRows, 4, smp.DateTime.ToShortDateString());
							writer.WriteCell(totalRows, 5, smp.DateTime.ToShortTimeString());
							writer.WriteCell(totalRows, 6, (double)smp.OCR_Observations_list[0].Value);//Press
							writer.WriteCell(totalRows, 7, (int)smp.OCR_Observations_list[1].Value);//Temp
							
							SpeciesObservation spc0 = (SpeciesObservation)smp.Species_Observations_list[0];
							writer.WriteCell(totalRows, 8, (string)spc0.Value);//Species0
							writer.WriteCell(totalRows, 9, (int)spc0.Count);//Count0
							
							//more than 1 specie observation, duplicate the row changing that value
							if(smp.OCR_Observations_list.Count>3)
							{
								for(int j=3;j<smp.OCR_Observations_list.Count;j++)
								{
									totalRows++;
									writer.WriteCell(totalRows, 0, st.StationID);
									writer.WriteCell(totalRows, 1, smp.CameraManufacturer);
									writer.WriteCell(totalRows, 2, smp.CameraModel);
									writer.WriteCell(totalRows, 3, smp.ImageName);
									writer.WriteCell(totalRows, 4, smp.DateTime.ToShortDateString());
									writer.WriteCell(totalRows, 5, smp.DateTime.ToShortTimeString());
									writer.WriteCell(totalRows, 6, (double)smp.OCR_Observations_list[0].Value);//Press
									writer.WriteCell(totalRows, 7, (int)smp.OCR_Observations_list[1].Value);//Temp
									
									SpeciesObservation spcN = (SpeciesObservation)smp.Species_Observations_list[j];
									writer.WriteCell(totalRows, 8, (string)spcN.Value);//Species0
									writer.WriteCell(totalRows, 9, (int)spcN.Count);//Count0
									
								}
							}
						}
					}
					
					writer.EndWrite();
					stream.Close();
				}
			} catch (Exception ex) {
				throw ex;
			}

		}
		
		#endregion
		
		#region Close and Exit
		
		void CloseProjectToolStripMenuItemClick(object sender, EventArgs e)
		{
			try {
				DialogResult result = MessageBox.Show("Would you like to save your changes?","Save project?",
				                                      MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				
				if (result == DialogResult.Yes)
				{
					ProjectDAO.UpdateProject(_currentProject.Name,_currentProject);
					ProjectDAO.RemoveOrphanImages(_currentProject);
				}
				else if (result == DialogResult.Cancel)
				{
					// Stop the closing and return to the form
					//	            e.Cancel = true;
				}
				else
				{
					tvProject.Nodes.Clear();
					pictureBox1.Image=null;
					_currentProject=null;
					_currentStation=null;
					_currentSample=null;
					lstViewData.Clear();
					dgvSelectSpecies.DataSource=null;
					speciesList.Rows.Clear();
				}
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		void ExitProgramToolStripMenuItemClick(object sender, EventArgs e)
		{
			ExitApplication();
		}
		
		void ExitApplication()
		{
			try {
				DialogResult result = MessageBox.Show("Would you like to save your changes?", "Save project?",
				                                      MessageBoxButtons.YesNo,MessageBoxIcon.Question);
				
				if (result == DialogResult.Yes)
				{
					ProjectDAO.UpdateProject(_currentProject.Name,_currentProject);
					ProjectDAO.RemoveOrphanImages(_currentProject);
					
					tvProject.Dispose();
					pictureBox1.Dispose();
					_currentProject=null;
					_currentStation=null;
					_currentSample=null;
					lstViewData.Dispose();
					dgvSelectSpecies.Dispose();
				}
				else if (result == DialogResult.Cancel)
				{
					//				Stop the closing and return to the form
					//				e.Cancel = true;
				}
			} catch (Exception ex) {
				throw ex;
			}

		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			ExitApplication();
		}
		
		#endregion
		

		

//		void CmsTreeViewOpening(object sender, System.ComponentModel.CancelEventArgs e)
//		{
//			if(tvProject.SelectedNode != null && tvProject.SelectedNode.GetType() == typeof(Station))
//			{
//				cntxtsbRemoveSample.Enabled=false;
//			}
//		}
		
		
		
		

		
		void ToolStripProgressBar1Click(object sender, EventArgs e)
		{
			
		}
	}
}
