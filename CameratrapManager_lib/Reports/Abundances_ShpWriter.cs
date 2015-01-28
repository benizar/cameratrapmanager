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
using System.Collections;
using System.Collections.Generic;
using GisSharpBlog.NetTopologySuite.IO;
using GisSharpBlog.NetTopologySuite.Geometries;
using GeoAPI.Geometries;

using CameratrapManager_lib.CameratrapModel;
using CameratrapManager_lib.Analysis;
using CameratrapManager_lib.Analysis.Queries;



namespace CameratrapManager_lib.Reports
{
	/// <summary>
	/// Description of Abundances_ShpWriter.
	/// </summary>
	public class Abundances_ShpWriter
	{
		public Abundances_ShpWriter(Project currentProject, string shapefileName)
		{
			WritePointAbundances(currentProject,shapefileName+"_point");
			WriteGridAbundances(currentProject,shapefileName+"_grid");
		}
		
		private void WriteGridAbundances(Project currentProject, string shapefileName)
		{
			try {
				List<IPolygon>projectGrids=new List<IPolygon>();
				General_queries projq=new General_queries(currentProject);
				
				foreach(Station st in currentProject.StationsList)
				{
					
					IPolygon grid=st.Grid;
					StationStats tempStationStats=new StationStats(st.Guid,st.StationID);
					
					foreach(StationStats stst in projq.AllStatsByStation)
					{
						if(stst.StationGUID==st.Guid)
						{
							tempStationStats=stst;
							grid.UserData=tempStationStats;
						}
					}
					
					projectGrids.Add(grid);
				}
				
				GeometryCollection gc=new GeometryCollection(projectGrids.ToArray());
				
				//Open Writer
				ShapefileWriter shpWriter = new ShapefileWriter();
				shpWriter.Write(shapefileName, gc);
				
				//Create Header & Columns for points
				DbaseFileHeader dbfHeader = new DbaseFileHeader();
				

				dbfHeader.AddColumn("Station_ID",'C',20,0);
				//One column for each species in project
				foreach(SpeciesStats spcst in projq.AllStatsBySpecies)
				{
					dbfHeader.AddColumn(spcst.SpeciesName,'N',20,0);
				}
				
				dbfHeader.NumRecords = gc.Count;
				
				//DBF Writer
				DbaseFileWriter dbfWriter = new DbaseFileWriter(shapefileName+".dbf");
				dbfWriter.Write(dbfHeader);
				
				//Loop through Business Object to get Features
				foreach (IPolygon p in gc.Geometries)
				{
					StationStats data = (StationStats)p.UserData;
					
					
					ArrayList columnValues = new System.Collections.ArrayList();
					//Add Values
					
					columnValues.Add(data.StationID);
					foreach(SpeciesStats s in data.SpeciesStats)
					{
						columnValues.Add(s.SpeciesPictures);
					}
					
					dbfWriter.Write(columnValues);

				}
				
				//Close File
				dbfWriter.Close();
			} catch (Exception ex) {
				throw ex;
			}
			

		}
		
		
		private void WritePointAbundances(Project currentProject, string shapefileName)
		{
			try {
				List<IPoint> points=new List<IPoint>();
				
				General_queries projq=new General_queries(currentProject);
				
				foreach(Station st in currentProject.StationsList)
				{
					IPoint p = new Point(st.Lon,st.Lat);
					StationStats tempStationStats=new StationStats(st.Guid,st.StationID);
					
					foreach(StationStats stst in projq.AllStatsByStation)
					{
						if(stst.StationGUID==st.Guid)
						{
							tempStationStats=stst;
							p.UserData=tempStationStats;
						}
					}
					
					points.Add(p);
				}
				
				List<IPoint>projPoints=new List<IPoint>();
				projPoints = Utilities.Projections.projectGPSto23030(points);
				
				
				GeometryCollection gc=new GeometryCollection(projPoints.ToArray());
				
				//Open Writer
				ShapefileWriter shpWriter = new ShapefileWriter();
				shpWriter.Write(shapefileName, gc);
				
				//Create Header & Columns for points
				DbaseFileHeader dbfHeader = new DbaseFileHeader();
				
				//One column for each species in project
				dbfHeader.AddColumn("Station_ID",'C',20,0);
				foreach(SpeciesStats spcst in projq.AllStatsBySpecies)
				{
					dbfHeader.AddColumn(spcst.SpeciesName,'N',20,0);
				}
				
				dbfHeader.NumRecords = gc.Count;
				
				//DBF Writer
				DbaseFileWriter dbfWriter = new DbaseFileWriter(shapefileName+".dbf");
				dbfWriter.Write(dbfHeader);
				
				//Loop through Business Object to get Features
				foreach (Point p in gc.Geometries)
				{
					StationStats data = (StationStats)p.UserData;
					
					
					ArrayList columnValues = new System.Collections.ArrayList();
					//Add Values
					columnValues.Add(data.StationID);
					foreach(SpeciesStats s in data.SpeciesStats)
					{
						columnValues.Add(s.SpeciesCount);
					}
					
					dbfWriter.Write(columnValues);

				}
				
				
				//Close File
				dbfWriter.Close();
			} catch (Exception ex) {
				throw ex;
			}
			
			
			
		}
		
		
	}
}
