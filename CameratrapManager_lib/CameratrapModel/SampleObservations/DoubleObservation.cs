/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 29/05/2011
 * Hora: 21:15
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Text.RegularExpressions;

using CameratrapManager_lib.OCR;

namespace CameratrapManager_lib.CameratrapModel.SampleObservations
{
	/// <summary>
	/// Description of DoubleObservation.
	/// </summary>
	/// 
	[Serializable]
	public class DoubleObservation:Observation
	{
		
		public DoubleObservation()
		{
		}
		
		
		public DoubleObservation(string Name, double Count):base(Name,Count)
		{
		}
		
		
		public DoubleObservation(string Name, string Value, OCR_Template OCR):base(Name,Value)
		{
			
			_OCR=OCR;
		}
		
		OCR_Template _OCR;
		
		
		public new double Value {
			get { return (double)_value; }
			set { _value = (double)value; }
		}
		
		
		internal override void DoOCR(string fullFilename)
		{
			if (_OCR != null)
			{		
				string ocrDouble=Tessnet2.OCRImageRegion(fullFilename,_OCR.OCRrect);
				
				Value= double.Parse(Regex.Replace(ocrDouble, "[^.0-9-]", ""),System.Globalization.CultureInfo.InvariantCulture);
			}
			
		}
		
		
		
		
	}
}
