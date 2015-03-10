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

using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;

namespace CameratrapManager.Carto
{
	/// <summary>
	/// Description of Projections.
	/// </summary>
	public class Projections
	{
		
		public static List<IPoint> projectGPSto23030(List<IPoint> wayPoints)
		{
			try {
				List<IPoint>projectedPoints=new List<IPoint>();
				
//			p_WGS84=new Point(Lon,Lat);
				
				string ED50= "PROJCS[\"ED50 / UTM zone 30N\",GEOGCS[\"ED50\",DATUM[\"European_Datum_1950\",SPHEROID[\"International 1924\",6378388,297,AUTHORITY[\"EPSG\",\"7022\"]],AUTHORITY[\"EPSG\",\"6230\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4230\"]],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",0],PARAMETER[\"central_meridian\",-3],PARAMETER[\"scale_factor\",0.9996],PARAMETER[\"false_easting\",500000],PARAMETER[\"false_northing\",0],AUTHORITY[\"EPSG\",\"23030\"],AXIS[\"Easting\",EAST],AXIS[\"Northing\",NORTH]]";
//			string WGS84 = "GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563,AUTHORITY[\"EPSG\",\"7030\"]],AUTHORITY[\"EPSG\",\"6326\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4326\"]]";
//			string ETRS89="PROJCS[\"ETRS89 / UTM zone 30N\",GEOGCS[\"ETRS89\",DATUM[\"European_Terrestrial_Reference_System_1989\",SPHEROID[\"GRS 1980\",6378137,298.257222101,AUTHORITY[\"EPSG\",\"7019\"]],AUTHORITY[\"EPSG\",\"6258\"]],PRIMEM[\"Greenwich\",0,AUTHORITY[\"EPSG\",\"8901\"]],UNIT[\"degree\",0.01745329251994328,AUTHORITY[\"EPSG\",\"9122\"]],AUTHORITY[\"EPSG\",\"4258\"]],UNIT[\"metre\",1,AUTHORITY[\"EPSG\",\"9001\"]],PROJECTION[\"Transverse_Mercator\"],PARAMETER[\"latitude_of_origin\",0],PARAMETER[\"central_meridian\",-3],PARAMETER[\"scale_factor\",0.9996],PARAMETER[\"false_easting\",500000],PARAMETER[\"false_northing\",0],AUTHORITY[\"EPSG\",\"25830\"],AXIS[\"Easting\",EAST],AXIS[\"Northing\",NORTH]]";
				
				var csf = new ProjNet.CoordinateSystems.CoordinateSystemFactory();
				
				var cs1 = ProjNet.CoordinateSystems.GeographicCoordinateSystem.WGS84;//csf.CreateFromWkt(WGS84);
				var cs2 = csf.CreateFromWkt(ED50);
				
				var ctf = new ProjNet.CoordinateSystems.Transformations.CoordinateTransformationFactory();
				var ct = ctf.CreateFromCoordinateSystems(cs1, cs2).MathTransform;
				
				foreach(IPoint p in wayPoints)
				{
					double[] point=new double[2];
					point[0]=p.X;
					point[1]=p.Y;
					
					double[] pointReturn = ct.Transform(point);
					IPoint projPoint= new Point(pointReturn[0],pointReturn[1]);
					projPoint.UserData=p.UserData;
					projectedPoints.Add(projPoint);
				}
				
				return projectedPoints;
				
			} catch (Exception ex) {
				throw ex;
			}



		}
		
		
		
	}
}
