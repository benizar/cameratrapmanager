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
