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
using GisSharpBlog.NetTopologySuite.IO;
using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;
using System.Collections;
using System.Collections.Generic;


namespace Core.Shape
{
	/// <summary>
	/// Description of LoadShapefile.
	/// </summary>
	public class LoadShapefile
	{
		public LoadShapefile(string filename, string epsg)
		{
			this.askGeometry(filename, epsg);
		}
		
		
		List<IPolygon> _polygons = new List<IPolygon>();


        public List<IPolygon> Polygons
        {
            get { return _polygons; }
        }
		
        
        private void askGeometry(string filename, string epsg)
        {
            try
            {
                GeometryFactory f = new GeometryFactory(new PrecisionModel(), Convert.ToInt16(epsg));
                using (ShapefileDataReader dr = new ShapefileDataReader(filename, f))
                {
                    if (dr.RecordCount > 0)
                    {

                        if (dr.ShapeHeader.ShapeType.ToString() == "Polygon")
                        {
                            while (dr.Read())
                            {
                                _polygons.Add((IPolygon)dr.Geometry);
                            }
                        }

                        else
                        {
                            throw new Exception("Geometry type is not Polygon");
                        }

                    }
                    else
                    {
                        throw new Exception("The selected shapefile does not contain any row");
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		
	}
}
