/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 12:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;

using CameratrapManager_lib.ImageProcessing;

using tessnet2;

using System.Text.RegularExpressions;

namespace CameratrapManager_lib.OCR
{
	/// <summary>
	/// Description of Tessnet2.
	/// </summary>
	public class Tessnet2
	{

		public static string OCRImageRegion(string img, Rectangle rect)
		{
			try {
				using (Bitmap image = (Bitmap)Utilities.ConversionUtilities.NonLockingOpen(img))
	            {            	
	
					Bitmap binarized = OCR_Preprocessing.PreprocessOCR(image,rect);
					
		            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
		            
		            
		            ocr.Init(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "eng", false);
	//	            ocr.Init(@"C:\Documents and Settings\BENITO\Mis documentos\SharpDevelop Projects\tessnet2\bin\Debug", "eng", false);
	//	            ocr.SetVariable("tessedit_char_whitelist", "0123456789.-"); // If digit only
		            List<tessnet2.Word> result = ocr.DoOCR(binarized, Rectangle.Empty);// Rectangle.Empty);
		            
		           
		            return result[0].Text;
				}
			} catch (Exception ex) {
				throw ex;
			}

        }
			
			
			
	}
}
