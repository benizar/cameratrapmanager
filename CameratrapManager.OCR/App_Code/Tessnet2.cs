//Camera Trap Manager. A C# desktop application for managing
//camera trap pictures and creating some reports (Excel, GIS, PDF, etc).
//Copyright (C) 2015 Benito M. Zaragozí
//Authors: Benito M. Zaragozí (www.gisandchips.org)
//Send comments and suggestions to benito.zaragozi@ua.es
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//GNU General Public License for more details.
//
//You should have received a copy of the GNU General Public License
//along with this program. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Drawing;
using CameratrapManager.ImageProcessing;

using tessnet2;

using System.Text.RegularExpressions;

namespace CameratrapManager.OCR
{
	/// <summary>
	/// Description of Tessnet2.
	/// </summary>
	public class Tessnet2
	{

		public static string OCRImageRegion(string img, Rectangle rect)
		{
			try {
				using (Bitmap image = (Bitmap)CameratrapManager.Carto.ConversionUtilities.NonLockingOpen(img))
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
