/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 29/05/2011
 * Hora: 21:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

using CameratrapManager_lib.OCR;

namespace CameratrapManager_lib.CameratrapModel.SampleObservations
{
	/// <summary>
	/// Description of StringObservation.
	/// </summary>
	/// 
	[Serializable]
	public class StringObservation:Observation
	{
		public StringObservation()
		{
			
		}
		
		public StringObservation(string Name, string Value):base(Name,Value)
		{
			
		}
		
		public StringObservation(string Name, string Value, OCR_Template OCR):base(Name,Value)
		{
			
			_OCR=OCR;
		}
		
		OCR_Template _OCR;
		
		
		
		public new string Value {
			get { return (string)_value; }
			set { _value = (string)value; }
		}
		
		
		internal override void DoOCR(string fullFilename)
		{
			if (_OCR != null)
			{				
				Value= Tessnet2.OCRImageRegion(fullFilename,_OCR.OCRrect);
			}
			
		}
		

	}
}
