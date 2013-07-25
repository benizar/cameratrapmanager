/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 16:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using CameratrapManager_lib.CameratrapModel.SampleObservations;

using GeoAPI.Geometries;

namespace CameratrapManager_lib.CameratrapModel
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
