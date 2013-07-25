/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 16/06/2011
 * Hora: 17:12
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
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
