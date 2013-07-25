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
using Fotofly.BitmapMetadataTools;
using Fotofly.MetadataQueries;
using System.Drawing;
using System.Collections.Generic;
using GeoAPI.Geometries;


namespace CameratrapManager_lib.CameratrapModel
{
	/// <summary>
	/// Description of Station.
	/// </summary>
	/// 
	[Serializable]
	public class Station
	{
		
		public Station(string stationID, IPolygon grid)
		{
			_stationID=stationID;
			_grid=grid;
		}
		
		/// <summary>
		/// Create a new Station object typing all the property values
		/// </summary>
		/// <param name="lat"></param>
		/// <param name="lon"></param>
		/// <param name="alt"></param>
		/// <param name="compass"></param>
		public Station (string stationID, IPolygon grid, double lat, double lon, double alt, double compass)
		{
			_lat=lat;
			_lon=lon;
			_alt=alt;
			_compass=compass;
			_stationID=stationID;
		}
		
		
		/// <summary>
		/// Create a new Station object providing a mainPicture which contains the required EXIF metadata
		/// </summary>
		/// <param name="image"></param>
		public Station(string stationID, IPolygon grid, string image)
		{			
			_stationID=stationID;
			_grid=grid;
			
			this.MetadataFromImage(image);
			
		}
		
		string _stationID;
		IPolygon _grid;
		string _guid=System.Guid.NewGuid().ToString();
		string _mainPictureFilename="Not Provided";
		double _lat=0;
		double _lon=0;
		double _alt=0;
		double _compass=0;
		List<Sample> _samplesList=new List<Sample>();

	
		
		public string StationID {
			get { return _stationID; }
		}
		
		
		public string Guid {
			get { return _guid; }
		}
		
		public IPolygon Grid {
			get { return _grid; }
		}
		

		public string MainPictureFilename {
			get { return _mainPictureFilename; }
			set { _mainPictureFilename = value; }
		}
		
		public double Lat {
			get { return _lat; }
			set { _lat = value; }
		}
		
		public double Lon {
			get { return _lon; }
			set { _lon = value; }
		}
		
		public double Alt {
			get { return _alt; }
			set { _alt = value; }
		}
		
		public double Compass {
			get { return _compass; }
			set { _compass = value; }
		}
		
		public List<Sample> SamplesList {
			get { return _samplesList; }
			set { _samplesList = value; }
		}
		

		public void MetadataFromImage(string image)
		{
			
			JpgPhoto mainPhoto = new JpgPhoto(image);
			_mainPictureFilename = image;
			
			_lat=mainPhoto.Metadata.GpsPositionOfLocationCreated.Latitude.Numeric;
			_lon=mainPhoto.Metadata.GpsPositionOfLocationCreated.Longitude.Numeric;
			_alt=mainPhoto.Metadata.GpsPositionOfLocationCreated.Altitude;
			
			//TODO: We need a Fotofly method for retrieving the compass metadata.
			//No standard in JpgPhoto class. We add references to PresentationCore and WindowsBase
			//from .NET 3.0
			WpfFileManager wpf = new WpfFileManager(image, false);
			URational urational = wpf.BitmapMetadata.GetQuery<URational>(GpsQueries.ImgDirection.Query);
			_compass=urational.ToDouble(3);
		}
		
		
	}
}
