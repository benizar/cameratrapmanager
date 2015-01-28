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

namespace CameratrapManager_lib.Analysis
{
	/// <summary>
	/// Description of MoonPhase.
	/// </summary>
	public class MoonPhaseCalculations
	{
		public MoonPhaseCalculations(DateTime UTC_Datetime)
		{
			_moonPhase=GetMoonPhase(UTC_Datetime);
		}
		
		string _moonPhase;
		
		
		public string MoonPhase {
			get { return _moonPhase; }
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dt">datetime UTC</param>
		/// <returns></returns>
		private string GetMoonPhase(DateTime dt)
		{
			try {
				int year = dt.Year;
				int month = dt.Month;
				int day = dt.Day;
				double c,e,jd;
				int b;
				
				if (month < 3)
				{
					year--;
					month += 12;
				}
				
				month++;
				c = 365.25 * year;
				e = 30.6 * month;
				jd = (c + e + day - 694039.09)/29.5305882;
				b = (int)jd;
				jd -= b;
				b = (int)Math.Round(jd * 8);
				
				if (b >= 8) b = 0;
				switch (b)
				{
					case 0:
					return "New Moon";
					case 1:
					return "Waxing Crescent Moon";
					case 2:
					return "Quarter Moon";
					case 3:
					return "Waxing Gibbous Moon";
					case 4:
					return "Full Moon";
					case 5:
					return "Waning Gibbous Moon";
					case 6:
					return "Last Quarter Moon";
					case 7:
					return "Waning Crescent Moon";
					default:
					return "Error";
				}
			} catch (Exception ex) {
				throw ex;
			}
		}
	
	
	
	}
}
