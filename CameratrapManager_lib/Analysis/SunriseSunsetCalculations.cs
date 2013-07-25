//Adapted from the Javascript code of the NOAA ESRL Sunrise/Sunset Calculator
//view-source:http://www.srrb.noaa.gov/highlights/sunrise/sunrise.html

/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 28/05/2011
 * Hora: 13:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace CameratrapManager_lib.Analysis
{
	/// <summary>
	/// Description of IsDayOrNight.
	/// </summary>
	public class SunriseSunsetCalculations
	{
		
		
		public SunriseSunsetCalculations(DateTime photoDate,double lat,double lon)
		{
			_isDay=this.DayOrNight(photoDate,lat,lon);
		}
		
		
		string _isDay;
		
		
		public string IsDay {
			get { return _isDay; }
		}
		
		
		
		private string DayOrNight(DateTime photoDate,double lat,double lon)
		{
			double JD = this.calcJD(photoDate.Year,photoDate.Month,photoDate.Day);
			double sunrise = this.calcSunriseUTC(JD,lat,lon);
			double sunset = this.calcSunsetUTC(JD,lat,lon);
			
			
			if(photoDate.ToUniversalTime().TimeOfDay.TotalMinutes > sunrise && photoDate.ToUniversalTime().TimeOfDay.TotalMinutes < sunset )
			{
				return "Is Day";
			}
			else
			{
				return "Is Night";
			}
			
		}
		
		
		
		
		/// <summary>
		/// Convert radian angle to degrees
		/// </summary>
		/// <param name="angleRad"></param>
		/// <returns></returns>
		private double radToDeg(double angleRad) 
		{
			return (180.0 * angleRad / Math.PI);
		}
		

		/// <summary>
		/// Convert degree angle to radians
		/// </summary>
		/// <param name="angleDeg"></param>
		/// <returns></returns>
		private double degToRad(double angleDeg) 
		{
			return (Math.PI * angleDeg / 180.0);
		}
		
		

		/// <summary>
		/// Julian day from calendar day. Note: Number is returned for start of day. Fractional days should be
		/// added later.
		/// </summary>
		/// <param name="year">4 digit year</param>
		/// <param name="month">January = 1</param>
		/// <param name="day">1 - 31</param>
		/// <returns>The Julian day corresponding to the date</returns>
		private double calcJD(int year, int month, int day)
		{
			if (month <= 2) {
			year -= 1;
			month += 12;
			}
			double A = Math.Floor(year/100.0);
			double B = 2 - A + Math.Floor(A/4);
			
			double JD = Math.Floor(365.25*(year + 4716)) + Math.Floor(30.6001*(month+1)) + day + B - 1524.5;
			return JD;
		}
		

		/// <summary>
		/// convert Julian Day to centuries since J2000.0.
		/// </summary>
		/// <param name="jd">the Julian Day to convert</param>
		/// <returns>the T value corresponding to the Julian Day</returns>
		private double calcTimeJulianCent(double jd)
		{
			double T = (jd - 2451545.0)/36525.0;
			return T;
		}
		
		
		/// <summary>
		/// convert centuries since J2000.0 to Julian Day.
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>the Julian Day corresponding to the t value</returns>
		private double calcJDFromJulianCent(double t)
		{
			double JD = t * 36525.0 + 2451545.0;
			return JD;
		}
		
		
		/// <summary>
		/// calculate the Geometric Mean Longitude of the Sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>the Geometric Mean Longitude of the Sun in degrees</returns>
		private double calcGeomMeanLongSun(double t)
		{
			double L0 = 280.46646 + t * (36000.76983 + 0.0003032 * t);
			while(L0 > 360.0)
			{
			L0 -= 360.0;
			}
			while(L0 < 0.0)
			{
			L0 += 360.0;
			}
			return L0;	 // in degrees
		}
		
		
		/// <summary>
		/// calculate the Geometric Mean Anomaly of the Sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>the Geometric Mean Anomaly of the Sun in degrees</returns>
		private double calcGeomMeanAnomalySun(double t)
		{
			double M = 357.52911 + t * (35999.05029 - 0.0001537 * t);
			return M;	 // in degrees
		}
		

		/// <summary>
		/// calculate the eccentricity of earth's orbit
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>the unitless eccentricity</returns>
		private double calcEccentricityEarthOrbit(double t)
		{
			double e = 0.016708634 - t * (0.000042037 + 0.0000001267 * t);
			return e;	 // unitless
		}
		

		/// <summary>
		/// calculate the equation of center for the sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>in degrees</returns>
		private double calcSunEqOfCenter(double t)
		{
			double m = calcGeomMeanAnomalySun(t);
			
			double mrad = degToRad(m);
			double sinm = Math.Sin(mrad);
			double sin2m = Math.Sin(mrad+mrad);
			double sin3m = Math.Sin(mrad+mrad+mrad);
			
			double C = sinm * (1.914602 - t * (0.004817 + 0.000014 * t)) + sin2m * (0.019993 - 0.000101 * t) + sin3m * 0.000289;
			return C;	 // in degrees
		}
		
		
		/// <summary>
		/// calculate the true longitude of the sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>sun's true longitude in degrees	</returns>
		private double calcSunTrueLong(double t)
		{
			double l0 = calcGeomMeanLongSun(t);
			double c = calcSunEqOfCenter(t);
			
			double O = l0 + c;
			return O;	 // in degrees
		}
		

		/// <summary>
		/// calculate the true anamoly of the sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>sun's true anamoly in degrees</returns>
		private double calcSunTrueAnomaly(double t)
		{
			double m = calcGeomMeanAnomalySun(t);
			double c = calcSunEqOfCenter(t);
			
			double v = m + c;
			return v;	 // in degrees
		}
		

		/// <summary>
		/// calculate the distance to the sun in AU
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>sun radius vector in AUs</returns>
		private double calcSunRadVector(double t)
		{
			double v = calcSunTrueAnomaly(t);
			double e = calcEccentricityEarthOrbit(t);
			
			double R = (1.000001018 * (1 - e * e)) / (1 + e * Math.Cos(degToRad(v)));
			return R;	 // in AUs
		}
		

		/// <summary>
		/// calculate the apparent longitude of the sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>sun's apparent longitude in degrees	</returns>
		private double calcSunApparentLong(double t)
		{
			double o = calcSunTrueLong(t);
			
			double omega = 125.04 - 1934.136 * t;
			double lambda = o - 0.00569 - 0.00478 * Math.Sin(degToRad(omega));
			return lambda;	 // in degrees
		}
		

		/// <summary>
		/// calculate the mean obliquity of the ecliptic
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>mean obliquity in degrees	</returns>
		private double calcMeanObliquityOfEcliptic(double t)
		{
			double seconds = 21.448 - t*(46.8150 + t*(0.00059 - t*(0.001813)));
			double e0 = 23.0 + (26.0 + (seconds/60.0))/60.0;
			return e0;	 // in degrees
		}
		

		/// <summary>
		/// calculate the corrected obliquity of the ecliptic
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>corrected obliquity in degrees	</returns>
		private double calcObliquityCorrection(double t)
		{
			double e0 = calcMeanObliquityOfEcliptic(t);
			
			double omega = 125.04 - 1934.136 * t;
			double e = e0 + 0.00256 * Math.Cos(degToRad(omega));
			return e;	 // in degrees
		}
		

		/// <summary>
		/// calculate the right ascension of the sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>sun's right ascension in degrees</returns>
		private double calcSunRtAscension(double t)
		{
			double e = calcObliquityCorrection(t);
			double lambda = calcSunApparentLong(t);
			
			double tananum = (Math.Cos(degToRad(e)) * Math.Sin(degToRad(lambda)));
			double tanadenom = (Math.Cos(degToRad(lambda)));
			double alpha = radToDeg(Math.Atan2(tananum, tanadenom));
			return alpha;	 // in degrees
		}
		

		/// <summary>
		/// calculate the declination of the sun
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>sun's declination in degrees</returns>
		private double calcSunDeclination(double t)
		{
			double e = calcObliquityCorrection(t);
			double lambda = calcSunApparentLong(t);
			
			double sint = Math.Sin(degToRad(e)) * Math.Sin(degToRad(lambda));
			double theta = radToDeg(Math.Asin(sint));
			return theta;	 // in degrees
		}
		

		/// <summary>
		/// calculate the difference between true solar time and mean	
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <returns>equation of time in minutes of time	</returns>
		private double calcEquationOfTime(double t)
		{
			double epsilon = calcObliquityCorrection(t);
			double l0 = calcGeomMeanLongSun(t);
			double e = calcEccentricityEarthOrbit(t);
			double m = calcGeomMeanAnomalySun(t);
			
			double y = Math.Tan(degToRad(epsilon)/2.0);
			y *= y;
			
			double sin2l0 = Math.Sin(2.0 * degToRad(l0));
			double sinm = Math.Sin(degToRad(m));
			double cos2l0 = Math.Cos(2.0 * degToRad(l0));
			double sin4l0 = Math.Sin(4.0 * degToRad(l0));
			double sin2m = Math.Sin(2.0 * degToRad(m));
			
			double Etime = y * sin2l0 - 2.0 * e * sinm + 4.0 * e * y * sinm * cos2l0
			- 0.5 * y * y * sin4l0 - 1.25 * e * e * sin2m;
			
			return radToDeg(Etime)*4.0;	// in minutes of time
		}
		

		/// <summary>
		/// calculate the hour angle of the sun at sunrise for the latitude
		/// </summary>
		/// <param name="lat">latitude of observer in degrees</param>
		/// <param name="solarDec">declination angle of sun in degrees</param>
		/// <returns>hour angle of sunrise in radians</returns>
		private double calcHourAngleSunrise(double lat, double solarDec)
		{
			double latRad = degToRad(lat);
			double sdRad = degToRad(solarDec);
			
			double HAarg = (Math.Cos(degToRad(90.833))/(Math.Cos(latRad)*Math.Cos(sdRad))-Math.Tan(latRad) * Math.Tan(sdRad));
			
			double HA = (Math.Acos(Math.Cos(degToRad(90.833))/(Math.Cos(latRad)*Math.Cos(sdRad))-Math.Tan(latRad) * Math.Tan(sdRad)));
			
			return HA;	 // in radians
		}
		

		/// <summary>
		/// calculate the hour angle of the sun at sunset for the latitude
		/// </summary>
		/// <param name="lat">latitude of observer in degrees</param>
		/// <param name="solarDec">declination angle of sun in degrees</param>
		/// <returns>hour angle of sunset in radians</returns>
		private double calcHourAngleSunset(double lat, double solarDec)
		{
			double latRad = degToRad(lat);
			double sdRad = degToRad(solarDec);
			
			double HAarg = (Math.Cos(degToRad(90.833))/(Math.Cos(latRad)*Math.Cos(sdRad))-Math.Tan(latRad) * Math.Tan(sdRad));
			
			double HA = (Math.Acos(Math.Cos(degToRad(90.833))/(Math.Cos(latRad)*Math.Cos(sdRad))-Math.Tan(latRad) * Math.Tan(sdRad)));
			
			return -HA;	 // in radians
		}
		
		
		/// <summary>
		/// calculate the Universal Coordinated Time (UTC) of sunrise
		/// for the given day at the given location on earth
		/// </summary>
		/// <param name="JD">julian day</param>
		/// <param name="latitude">latitude of observer in degrees</param>
		/// <param name="longitude">longitude of observer in degrees</param>
		/// <returns>time in minutes from zero Z</returns>
		private double calcSunriseUTC(double JD, double latitude, double longitude)
		{
			double t = calcTimeJulianCent(JD);
			
			// *** Find the time of solar noon at the location, and use
			// that declination. This is better than start of the 
			// Julian day
			
			double noonmin = calcSolNoonUTC(t, longitude);
			double tnoon = calcTimeJulianCent (JD+noonmin/1440.0);
			
			// *** First pass to approximate sunrise (using solar noon)
			
			double eqTime = calcEquationOfTime(tnoon);
			double solarDec = calcSunDeclination(tnoon);
			double hourAngle = calcHourAngleSunrise(latitude, solarDec);
			
			double delta = longitude - radToDeg(hourAngle);
			double timeDiff = 4 * delta;	// in minutes of time
			double timeUTC = 720 + timeDiff - eqTime;	// in minutes
			
			// alert("eqTime = " + eqTime + "\nsolarDec = " + solarDec + "\ntimeUTC = " + timeUTC);
			
			// *** Second pass includes fractional jday in gamma calc
			
			double newt = calcTimeJulianCent(calcJDFromJulianCent(t) + timeUTC/1440.0); 
			eqTime = calcEquationOfTime(newt);
			solarDec = calcSunDeclination(newt);
			hourAngle = calcHourAngleSunrise(latitude, solarDec);
			delta = longitude - radToDeg(hourAngle);
			timeDiff = 4 * delta;
			timeUTC = 720 + timeDiff - eqTime; // in minutes
			
			// alert("eqTime = " + eqTime + "\nsolarDec = " + solarDec + "\ntimeUTC = " + timeUTC);
			
			return timeUTC;
		}
		

		/// <summary>
		/// calculate the Universal Coordinated Time (UTC) of solar
		/// noon for the given day at the given location on earth
		/// </summary>
		/// <param name="t">number of Julian centuries since J2000.0</param>
		/// <param name="longitude">longitude of observer in degrees</param>
		/// <returns>time in minutes from zero Z	</returns>
		private double calcSolNoonUTC(double t, double longitude)
		{
			// First pass uses approximate solar noon to calculate eqtime
			double tnoon = calcTimeJulianCent(calcJDFromJulianCent(t) + longitude/360.0);
			double eqTime = calcEquationOfTime(tnoon);
			double solNoonUTC = 720 + (longitude * 4) - eqTime; // min
			
			double newt = calcTimeJulianCent(calcJDFromJulianCent(t) -0.5 + solNoonUTC/1440.0); 
			
			eqTime = calcEquationOfTime(newt);
			// double solarNoonDec = calcSunDeclination(newt);
			solNoonUTC = 720 + (longitude * 4) - eqTime; // min
			
			return solNoonUTC;
		}
		

		/// <summary>
		/// calculate the Universal Coordinated Time (UTC) of sunset
		/// for the given day at the given location on earth
		/// </summary>
		/// <param name="JD">julian day</param>
		/// <param name="latitude">latitude of observer in degrees</param>
		/// <param name="longitude">longitude of observer in degrees</param>
		/// <returns>time in minutes from zero Z</returns>
		private double calcSunsetUTC(double JD, double latitude, double longitude)
		{
			double t = calcTimeJulianCent(JD);
			
			// *** Find the time of solar noon at the location, and use
			// that declination. This is better than start of the 
			// Julian day
			
			double noonmin = calcSolNoonUTC(t, longitude);
			double tnoon = calcTimeJulianCent (JD+noonmin/1440.0);
			
			// First calculates sunrise and approx length of day
			
			double eqTime = calcEquationOfTime(tnoon);
			double solarDec = calcSunDeclination(tnoon);
			double hourAngle = calcHourAngleSunset(latitude, solarDec);
			
			double delta = longitude - radToDeg(hourAngle);
			double timeDiff = 4 * delta;
			double timeUTC = 720 + timeDiff - eqTime;
			
			// first pass used to include fractional day in gamma calc
			
			double newt = calcTimeJulianCent(calcJDFromJulianCent(t) + timeUTC/1440.0); 
			eqTime = calcEquationOfTime(newt);
			solarDec = calcSunDeclination(newt);
			hourAngle = calcHourAngleSunset(latitude, solarDec);
			
			delta = longitude - radToDeg(hourAngle);
			timeDiff = 4 * delta;
			timeUTC = 720 + timeDiff - eqTime; // in minutes
			
			return timeUTC;
		}
		
	}
}
