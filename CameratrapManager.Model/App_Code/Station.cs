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
using Fotofly;
using Fotofly.BitmapMetadataTools;
using Fotofly.MetadataQueries;
using System.Drawing;
using System.Collections.Generic;
using GeoAPI.Geometries;


namespace CameratrapManager.Model
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
