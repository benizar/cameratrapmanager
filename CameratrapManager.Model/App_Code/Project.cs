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
using System.Collections.Generic;
using CameratrapManager_lib.CameratrapModel.SampleObservations;

using GeoAPI.Geometries;

namespace CameratrapManager.Model
{
	/// <summary>
	/// Description of Project.
	/// </summary>
	/// 
	[Serializable]
	public class Project
	{
		public Project()
		{
		}
		
		public Project(string name, string type, string creator, 
		               string subject, string description, DateTime startDate, 
		               DateTime completionDate, List<IPolygon> studyArea, int gridSize)
		{
			_name=name;
			_type=type;
			_creator =creator;
			_subject=subject;
			_description=description;
			_startDate=startDate;
			_completionDate=completionDate;
			_studyArea=studyArea;
			this.CreateGrid(_studyArea,gridSize);
			this.StationsListFromGrid();
		}
		
		string _name;
		string _type;
		string _creator;
		string _subject;
		string _description;
		DateTime _startDate;
		DateTime _completionDate;
		List<string> _speciesList=new List<string>();
		List<Station> _stationsList=new List<Station>();
		
		List<IPolygon>_studyArea;
		List<IPolygon>_grid;
		
		

		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		
		public string Type {
			get { return _type; }
			set { _type = value; }
		}
		
		public string Creator {
			get { return _creator; }
			set { _creator = value; }
		}
		
		public string Subject {
			get { return _subject; }
			set { _subject = value; }
		}
		
		public string Description {
			get { return _description; }
			set { _description = value; }
		}
		
		public DateTime StartDate {
			get { return _startDate; }
			set { _startDate = value; }
		}
		
		public DateTime CompletionDate {
			get { return _completionDate; }
			set { _completionDate = value; }
		}
		
		public List<string> SpeciesList {
			get { return _speciesList; }
			set { _speciesList = value; }
		}
		
		public List<Station> StationsList {
			get { return _stationsList; }
			set { _stationsList = value; }
		}
		
		public List<IPolygon> StudyArea {
			get { return _studyArea; }
		}
		
		public List<IPolygon> Grid {
			get { return _grid; }
		}
		
		
		
		private void CreateGrid(List<IPolygon> bounds, int gridSize)
		{
			Utilities.GraticuleBuilder grid=new CameratrapManager_lib.Utilities.GraticuleBuilder(_studyArea,gridSize,gridSize);
			_grid = grid.Graticule;
		}
		
		private void StationsListFromGrid()
		{
			foreach(IPolygon pol in _grid)
			{
				_stationsList.Add(new Station((string)pol.UserData,pol));
			}
		}
		
		
	}
}
