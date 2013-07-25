/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 16:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using Fotofly;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using CameratrapManager_lib.CameratrapModel.SampleObservations;

namespace CameratrapManager_lib.CameratrapModel
{
	/// <summary>
	/// Description of Sample.
	/// </summary>
	/// 
	[Serializable]
	public class Sample
	{
		public Sample()
		{
			
		}
		
		public Sample(double lat, double lon, string image)
		{
			_lat=lat;
			_lon=lon;
			_imageName=image;
			
			JpgPhoto photo = new JpgPhoto(image);
			_cameraModel=photo.Metadata.CameraModel;
			_cameraManufacturer=photo.Metadata.CameraManufacturer;
			_height=photo.Metadata.ImageHeight;
			_width=photo.Metadata.ImageWidth;
			_verticalResolution=photo.Metadata.VerticalResolution;
			_horizontalResolution=photo.Metadata.HorizontalResolution;
			_dateTime=photo.Metadata.DateTaken;
			
			Analysis.SunriseSunsetCalculations isDay=new Analysis.SunriseSunsetCalculations(_dateTime,lat,lon);
			_dayOrNight=isDay.IsDay;
			
			Analysis.MoonPhaseCalculations moon= new Analysis.MoonPhaseCalculations(_dateTime.ToUniversalTime() );
			_moonPhase=moon.MoonPhase;
//			_cameraFlash=photo.Metadata.f
			
//			_idBase64picture = ImageProcessing.ImageUtilities.ImageToBase64( Image.FromFile(image),System.Drawing.Imaging.ImageFormat.Jpeg);
			
		}
		
		string _guid=System.Guid.NewGuid().ToString();
		double _lat=0;
		double _lon=0;
		string _imageName;
		string _cameraModel;
		string _cameraManufacturer;
		int _height=0;
		int _width=0;
		int _verticalResolution;
		int _horizontalResolution;
		DateTime _dateTime;
		string _dayOrNight;
		string _moonPhase;

		List<Observation> _OCR_obs=new List<Observation>();
		List<SpeciesObservation> _species_obs=new List<SpeciesObservation>();
		
		

		public string Guid {
			get { return _guid; }
		}
		
		
		public double Lat {
			get { return _lat; }
			set { _lat = value; }
		}
		
		public double Lon {
			get { return _lon; }
			set { _lon = value; }
		}
		
		public string ImageName {
			get { return _imageName; }
			set { _imageName = value; }
		}
		
		public string CameraModel {
			get { return _cameraModel; }
			set { _cameraModel = value; }
		}
		
		public string CameraManufacturer {
			get { return _cameraManufacturer; }
			set { _cameraManufacturer = value; }
		}
		
		public int Height {
			get { return _height; }
			set { _height = value; }
		}
		
		public int Width {
			get { return _width; }
			set { _width = value; }
		}
		
		public int VerticalResolution {
			get { return _verticalResolution; }
			set { _verticalResolution = value; }
		}
		
		public int HorizontalResolution {
			get { return _horizontalResolution; }
			set { _horizontalResolution = value; }
		}
		
		public DateTime DateTime {
			get { return _dateTime; }
			set { _dateTime = value; }
		}
		
		public string DayOrNight {
			get { return _dayOrNight; }
			set { _dayOrNight = value; }
		}
		
		public string MoonPhase {
			get { return _moonPhase; }
			set { _moonPhase = value; }
		}
		
		
		public List<Observation> OCR_Observations_list {
			get { return _OCR_obs; }
			set { _OCR_obs = value; }
		}
		
		public List<SpeciesObservation> Species_Observations_list {
			get { return _species_obs; }
			set { _species_obs = value; }
		}
		

		
		
		public void RunOCR(List<Observation> observs)
		{
			foreach( Observation obs in observs)
			{
				obs.DoOCR(_imageName);
			}

		}
		
		
		
	}
}
