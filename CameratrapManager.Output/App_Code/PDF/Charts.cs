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

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Shapes.Charts;

using CameratrapManager.Model;
using CameratrapManager.Analysis;
using CameratrapManager.Analysis.Queries;
//using CameratrapManager_lib.CameratrapModel.SampleObservations;

namespace CameratrapManager.Output.PDF
{
	/// <summary>
	/// Description of Charts.
	/// </summary>
  public class Charts
  {
    public static void DefineCharts(Document document, Project currentProject)
    {
    	try {
	    	Paragraph paragraph = document.LastSection.AddParagraph("Charts", "Heading1");
	    	paragraph.AddBookmark("Charts");
	
	    	SpeciesPicturesInProject_PieChart(document, currentProject);
	    	
//	    	Paragraph paragraph = document.LastSection.AddParagraph("Charts", "Heading1");
//	    	paragraph.AddBookmark("Charts");
	
//	    	SpeciesCountInProject_PieChart(document, currentProject);
	    	SpeciesTimeBehavior_BarChart(document, currentProject);
	    	
    	} catch (Exception ex) {
    		throw ex;
    	}
    
    }
    
    public static void SpeciesCountInProject_PieChart(Document document, Project currentProject)
    {
    	try {
	    	General_queries projq =new General_queries(currentProject);
	    	List<SpeciesStats> stats = projq.AllStatsBySpecies;
	    	
	    	double[] speciesCount=new double[stats.Count];
	    	string[] speciesNames=new string[stats.Count];
	    	
	    	double speciesSum=0;
	    	
	    	for(int i=0; i<stats.Count;i++)
	    	{
	    		speciesSum += stats[i].SpeciesPictures;
	    		speciesCount[i]=stats[i].SpeciesCount;
	    		speciesNames[i]=stats[i].SpeciesName;
	    	}
	    	
	    	document.LastSection.AddParagraph("Species count in project", "Heading2");
	
	      	Chart chart = new Chart();
	      	chart.Type=ChartType.Pie2D;
			chart.Left = 0;
		
		    chart.Width = Unit.FromCentimeter(10);
		    chart.Height = Unit.FromCentimeter(8);
		    
		    Series series = chart.SeriesCollection.AddSeries();
		    series.Add(speciesCount);
		    XSeries xseries = chart.XValues.AddXSeries();
		    xseries.Add(speciesNames);
		    
		    chart.RightArea.AddLegend();
		    
		    chart.DataLabel.Type = DataLabelType.Percent;
		    chart.DataLabel.Position = DataLabelPosition.OutsideEnd;
		    
		
		    document.LastSection.Add(chart);
    	} catch (Exception ex) {
    		throw ex;
    	}
    	
    	
    }
    
    public static void SpeciesPicturesInProject_PieChart(Document document, Project currentProject)
    {
    	try {
	    	General_queries projq =new General_queries(currentProject);
	    	List<SpeciesStats> stats = projq.AllStatsBySpecies;
	    	
	    	double[] speciesPictures=new double[stats.Count];
	    	string[] speciesNames=new string[stats.Count];
	    	
	    	double speciesSum=0;
	    	
	    	for(int i=0; i<stats.Count;i++)
	    	{
	    		speciesSum += stats[i].SpeciesPictures;
	    		speciesPictures[i]=stats[i].SpeciesPictures;
	    		speciesNames[i]=stats[i].SpeciesName;
	    	}
	    	
	    	document.LastSection.AddParagraph("Pictures in project where the species appears", "Heading2");
	
	      	Chart chart = new Chart();
	      	chart.Type=ChartType.Pie2D;
			chart.Left = 0;
		
		    chart.Width = Unit.FromCentimeter(10);
		    chart.Height = Unit.FromCentimeter(8);
		    
		    Series series = chart.SeriesCollection.AddSeries();
		    series.Add(speciesPictures);
		    XSeries xseries = chart.XValues.AddXSeries();
		    xseries.Add(speciesNames);
		    
		    chart.RightArea.AddLegend();
		    
		    chart.DataLabel.Type = DataLabelType.Percent;
		    chart.DataLabel.Position = DataLabelPosition.OutsideEnd;
		    
		
		    document.LastSection.Add(chart);
    	} catch (Exception ex) {
    		throw ex;
    	}
    	
    	
    }
    
    public static void SpeciesTimeBehavior_BarChart(Document document, Project currentProject)
    {
    	try {
    		
    		General_queries projq =new General_queries(currentProject);
    		
    		
    		foreach(SpeciesStats spst in projq.AllStatsBySpecies)
    		{

    			document.LastSection.AddParagraph(spst.SpeciesName + " Activity Patterns", "Heading2");

    			Chart chart = new Chart();
    			chart.Left = 0;

    			chart.Width = Unit.FromCentimeter(16);
    			chart.Height = Unit.FromCentimeter(12);
    			Series series = chart.SeriesCollection.AddSeries();
    			series.ChartType = ChartType.Column2D;
    			series.Add(spst.ActivityPatern);
    			series.HasDataLabel = true;

    			XSeries xseries = chart.XValues.AddXSeries();
    			xseries.Add("0","1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14","15","16","17","18","19","20","21","22","23");

    			chart.XAxis.MajorTickMark = TickMarkType.Outside;
    			chart.XAxis.Title.Caption = "Hours of day";
    			
    			chart.YAxis.MajorTickMark = TickMarkType.Outside;
    			chart.YAxis.HasMajorGridlines = true;
    			chart.YAxis.MajorGridlines.LineFormat.Color=Colors.DarkGray;
    			chart.YAxis.Title.Caption = "Freq";

    			chart.PlotArea.LineFormat.Color = Colors.DarkGray;
    			chart.PlotArea.LineFormat.Width = 1;

    			document.LastSection.Add(chart);
    		
    		}
      
    	} catch (Exception ex) {
    		throw ex;
    	}
    }
    
    
  }
}
