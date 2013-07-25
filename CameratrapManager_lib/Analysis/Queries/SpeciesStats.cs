/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 13/06/2011
 * Hora: 10:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace CameratrapManager_lib.Analysis.Queries
{
	/// <summary>
	/// Description of SpeciesStats.
	/// </summary>
	public class SpeciesStats
	{
		
		public SpeciesStats()
		{
		}
		
		public SpeciesStats(string speciesName, int speciesCount, int speciesPictures)
		{
			_speciesName=speciesName;
			_speciesCount=speciesCount;
			_speciesPictures=speciesPictures;
		}
		
		string _speciesName;
		int _speciesCount=0;
		int _speciesPictures=0;
		double[]_activityPatern=new double[23];
		
		
		public string SpeciesName {
			get { return _speciesName; }
			set { _speciesName = value; }
		}
		
		public int SpeciesCount {
			get { return _speciesCount; }
			set { _speciesCount = value; }
		}
		
		public int SpeciesPictures {
			get { return _speciesPictures; }
			set { _speciesPictures = value; }
		}
		
		public double[] ActivityPatern {
			get { return _activityPatern; }
			set { _activityPatern = value; }
		}
		
		
		
	}
}
