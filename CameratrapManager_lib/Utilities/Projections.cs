/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 20/06/2011
 * Hora: 0:59
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;

namespace CameratrapManager_lib.Utilities
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
