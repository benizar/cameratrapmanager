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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CameratrapManager.Model;
using CameratrapManager.DAO;
using GeoAPI.Geometries;
using Core.Shape;

namespace CameratrapManager
{
	/// <summary>
	/// Description of NewProjectForm.
	/// </summary>
	public partial class NewProjectForm : Form
	{			
		
		Project _newProjectCreated = null;
		List<IPolygon> _studyArea = null;
		bool _isCreated = false;
		
		public Project NewProjectCreated {
			get { return _newProjectCreated; }
		}
		
		public bool isCreated{
			get{return _isCreated;}
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
				if(_studyArea != null)
				{			
					_newProjectCreated = new Project(txtProjectName.Text,
			                        cmbProjectType.Text,
			                        txtProjectCreator.Text,
			                        txtProjectSubject.Text,
			                        txtProjectDescription.Text,
			                        DateTime.Now,
			                        DateTime.Now,
			                        _studyArea, Convert.ToInt16(txtGridSize.Text));
					ProjectDAO.CreateNewProject(_newProjectCreated);
					_isCreated = true;
				}
				else{
					MessageBox.Show("Debe seleccionar un área de estudio para poder crear un proyecto.","Atención",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				
				
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
