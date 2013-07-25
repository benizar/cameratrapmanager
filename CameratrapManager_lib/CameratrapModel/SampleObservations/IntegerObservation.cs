/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 29/05/2011
 * Hora: 21:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Text.RegularExpressions;

using CameratrapManager_lib.OCR;

namespace CameratrapManager_lib.CameratrapModel.SampleObservations
{
	/// <summary>
	/// Description of IntegerObservation.
	/// </summary>
	/// 
	[Serializable]
	public class IntegerObservation:Observation
	{
		
		
		public IntegerObservation()
		{
		}
		
		public IntegerObservation(string Name, int Count):base(Name,Count)
		{

		}
		
		
		public IntegerObservation(string Name, string Value, OCR_Template OCR):base(Name,Value)
		{
			
			_OCR=OCR;
		}
		
		OCR_Template _OCR;
		
		
		
		
		public new int Value {
			get { return (int)_value; }
			set { _value = (int)value; }
		}
		
		
		internal override void DoOCR(string fullFilename)
		{
			if (_OCR != null)
			{		
				string ocrInt=Tessnet2.OCRImageRegion(fullFilename,_OCR.OCRrect);
				
				Value= int.Parse((Regex.Replace(ocrInt, "[^0-9-]", "")));				
				
				
				
			}
			
		}
		
	}
}
