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
