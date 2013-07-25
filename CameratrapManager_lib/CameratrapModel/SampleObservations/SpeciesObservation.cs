/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 29/05/2011
 * Hora: 21:17
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace CameratrapManager_lib.CameratrapModel.SampleObservations
{
	/// <summary>
	/// Description of SpeciesObservation.
	/// </summary>
	/// 
	[Serializable]
	public class SpeciesObservation:Observation
	{
		public SpeciesObservation()
		{
			
		}
		
		public SpeciesObservation(string Name, string Value, int Count):base(Name,Value)
		{
			_count=Count;
		}
		
		int _count;
		
		
		public new string Value {
			get { return (string)_value; }
			set { _value = (string)value; }
		}
		
		public int Count {
			get { return (int)_count; }
			set { _count = (int)value; }
		}
		
		
	}
}
