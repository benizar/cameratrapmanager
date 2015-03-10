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
using GisSharpBlog.NetTopologySuite.Geometries;
using GeoAPI.Geometries;
using System.Collections;
using System.Collections.Generic;

namespace CameratrapManager.Carto
{
	/// <summary>
	/// Description of GraticuleBuilder.
	/// </summary>
	public class GraticuleBuilder
	{
		public GraticuleBuilder(List<IPolygon> bounds,int cellWidth, int cellHeight)
		{
			TotalEnvelope(bounds,cellWidth,cellHeight);
			roundedRectangle(_totalAreaEnvelope,cellWidth,cellHeight);
			_completeGraticule = tessellator(cellWidth,cellHeight,_gridRows,_gridCols);
			_graticule=gridFilter(_completeGraticule,_totalArea);
		}
		
		IPolygon _totalArea;
		IPolygon _totalAreaEnvelope;
		IPolygon _roundedRectangle;
		IPoint _origin;
		List<IPolygon>_completeGraticule=new List<IPolygon>();
		List<IPolygon>_graticule=new List<IPolygon>();
		int _gridRows=0;
		int _gridCols=0;
		
		

		public List<IPolygon> Graticule {
			get { return _graticule; }
		}

		
		
		private void TotalEnvelope(List<IPolygon> bounds, int cellWidth, int cellHeight)
		{
			try {
				IPolygon totalArea=bounds[0];

				foreach(IPolygon pol in bounds)
				{
					totalArea.Union(pol);
				}
				
				_totalArea=totalArea;
				_totalAreaEnvelope=(IPolygon)totalArea.Envelope;
				
				double minX=0;
				double minY=0;
				
				foreach(Coordinate c in _totalAreaEnvelope.Coordinates)
				{
					minX = c.X;
					minY = c.Y;
					
					if(c.X < minX)
					{
						minX=c.X;
					}
					if(c.Y<minY)
					{
						minY=c.Y;
					}
				}
				
				_origin=new Point(minX,minY);
			} catch (Exception ex) {
				throw ex;
			}
			

		}
		
		
		/// <summary>
		/// Create a rectangle containing the study area and dividible by the desired grid size
		/// </summary>
		/// <param name="pol"></param>
		/// <param name="widthDivBy"></param>
		/// <param name="heightDivBy"></param>
		private void roundedRectangle(IPolygon pol, int widthDivBy, int heightDivBy)
		{
			try {
				double width = new  LineSegment(pol.Coordinates[0],pol.Coordinates[1]).Length;
				double height = new LineSegment(pol.Coordinates[1],pol.Coordinates[2]).Length;
				
				var roundedWidth = (int) Math.Sign(width) * Math.Ceiling(Math.Abs(width)/widthDivBy) * widthDivBy;
				var roundedHeight= (int) Math.Sign(height) * Math.Ceiling(Math.Abs(height)/heightDivBy) * heightDivBy;
				
				//get the total num of cols and rows
				_gridCols=(int)roundedWidth/widthDivBy;
				_gridRows=(int)roundedHeight/heightDivBy;
				
				
				ICoordinate origin =(ICoordinate)pol.Coordinates[0];
				
				ICoordinate[] coords=new ICoordinate[5];
				coords[0]= origin;
				coords[1]= new Coordinate(origin.X+roundedWidth, origin.Y);
				coords[2]= new Coordinate(origin.X+roundedWidth,origin.Y+roundedHeight);
				coords[3]= new Coordinate(origin.X,origin.Y+roundedHeight);
				coords[4]= origin;
				
				ILinearRing lr=new LinearRing(coords);
				
				_roundedRectangle=new Polygon(lr);
				
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		private List<IPolygon> tessellator(int cellWidth, int cellHeight, int numRows, int numColumns)
		{
			try {
				GeometryFactory f = new GeometryFactory();
				List<IPolygon> grid = new List<IPolygon>();
				double x = _origin.X;// pol.Coordinates[0].X;
				double y = _origin.Y;//pol.Coordinates[0].Y;
				for (int i = 1; i <= numColumns; i++)
				{
					for (int j = 1; j <= numRows; j++)
					{
						Coordinate[] coords;

						coords = new Coordinate[] {
							new Coordinate(x, y),
							new Coordinate(x + cellWidth, y),
							new Coordinate(x + cellWidth, y + cellHeight),
							new Coordinate(x, y+cellHeight),
							new Coordinate(x, y)};
						
						LinearRing ring  = (LinearRing) f.CreateLinearRing(coords);
						
						IPolygon newpol=(IPolygon) f.CreatePolygon(ring, null);
						newpol.UserData=i+" - "+j;
						grid.Add(newpol);
						y += cellHeight;
					}
					if(i!=0)
					{
						x += cellWidth;
					}
					y = _origin.Y;
				}
				return grid;
			} catch (Exception ex) {
				throw ex;
			}
			
			
		}
		
		private List<IPolygon> gridFilter(List<IPolygon> tessellation, IPolygon pol)
		{
			try {
				List<IPolygon>filteredGrid=new List<IPolygon>();
				
				foreach(IPolygon p in tessellation)
				{
					if(p.Intersects(pol)==true)
					{
						filteredGrid.Add(p);
					}
				}
				
				return filteredGrid;
			} catch (Exception ex) {
				throw ex;
			}
			
		}
	}
}

