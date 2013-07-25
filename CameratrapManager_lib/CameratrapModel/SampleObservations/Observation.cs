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
	/// Description of Observation.
	/// </summary>
	/// 
	[Serializable]
	public class Observation
	{
		
		public Observation()
		{
			
		}
		
		
		public Observation(string Name, object Value)
		{
			this.BuildObservation(Name,Value);
		}
		
		
		string _name;
		protected object _value;
		
		
		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		
		public object Value {
			get { return _value; }
			set { _value = value; }
		}
		
		
		private void BuildObservation(string Name, object Value)
		{
			_name=Name;
			_value=Value;
		}
		
		internal virtual void DoOCR(string fullFilename)
		{
		}
		
	}
}
