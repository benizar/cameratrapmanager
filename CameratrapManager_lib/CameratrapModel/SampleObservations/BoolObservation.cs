/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 29/05/2011
 * Hora: 21:15
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace CameratrapManager_lib.CameratrapModel.SampleObservations
{
	/// <summary>
	/// Description of BoolObservation.
	/// </summary>
	/// 
	[Serializable]
	public class BoolObservation:Observation
	{
		
		public BoolObservation()
		{
		}
		
		public BoolObservation(string Name, bool Value):base(Name,Value)
		{
		}
		
		
		public new bool Value {
			get { return (bool)_value; }
			set { _value = (bool)value; }
		}
	
	}
}
