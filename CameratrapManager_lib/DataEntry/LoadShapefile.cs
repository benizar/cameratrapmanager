/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 19/06/2011
 * Hora: 21:30
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using GisSharpBlog.NetTopologySuite.IO;
using GeoAPI.Geometries;
using GisSharpBlog.NetTopologySuite.Geometries;
using System.Collections;
using System.Collections.Generic;


namespace CameratrapManager_lib.DataEntry
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
