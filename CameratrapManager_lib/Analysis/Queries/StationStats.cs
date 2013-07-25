/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 13/06/2011
 * Hora: 16:50
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace CameratrapManager_lib.Analysis.Queries
{
	/// <summary>
	/// Description of StationStats.
	/// </summary>
	public class StationStats
	{
		public StationStats(string stationGUID, string stationID)
		{
			_stationGUID=stationGUID;
			_stationID=stationID;
		}
		
		string _stationID;
		string _stationGUID;
		List<SpeciesStats>_speciesStats=new List<SpeciesStats>();
		
		
		public string StationID {
			get { return _stationID; }
		}
		
		
		public string StationGUID {
			get { return _stationGUID; }
		}
		
		
		public List<SpeciesStats> SpeciesStats {
			get { return _speciesStats; }
			set { _speciesStats = value; }
		}
		
	}
}
