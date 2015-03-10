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
using MigraDoc.DocumentObjectModel.Tables;

using CameratrapManager.Model;
using CameratrapManager.Analysis;
using CameratrapManager.Model.Queries;


namespace CameratrapManager.Output.PDF
{
	/// <summary>
	/// Description of Tables.
	/// </summary>
  public class Tables
  {
    public static void DefineTables(Document document, Project currentProject)
    {
      Paragraph paragraph = document.LastSection.AddParagraph("Tables", "Heading1");
      paragraph.AddBookmark("Tables");

      StatsBySpecies_Table(document, currentProject);
      StatsByStations_Table(document, currentProject);
      
//      DemonstrateSimpleTable(document);
//      DemonstrateAlignment(document);
//      DemonstrateCellMerge(document);
    }

    public static void StatsBySpecies_Table(Document document, Project currentProject)
    {
    	try {
	    	General_queries prjq=new General_queries(currentProject);
	    	List<SpeciesStats> stats = prjq.AllStatsBySpecies;
	    	
	    	document.LastSection.AddParagraph("Statistics by species", "Heading2");
	
		    Table table = document.LastSection.AddTable();
		    table.Borders.Visible = true;
		    table.TopPadding = 10;
		    table.BottomPadding = 10;
		
		    Column column = table.AddColumn(Unit.FromCentimeter(5));
		    column.Format.Alignment = ParagraphAlignment.Center;
		    
		
		    column = table.AddColumn();
		    column.Format.Alignment = ParagraphAlignment.Center;
		
		    column = table.AddColumn();
		    column.Format.Alignment = ParagraphAlignment.Center;
		
		    table.Rows.Height = 20;
		
		    Row row = table.AddRow();
		    row.Shading.Color = Colors.PaleGoldenrod;
		    
		    row.Cells[0].AddParagraph().AddFormattedText("Species", TextFormat.Bold);
		    row.Cells[1].AddParagraph().AddFormattedText("Valid pictures",TextFormat.Bold);
		    row.Cells[2].AddParagraph().AddFormattedText("Species count", TextFormat.Bold);
		    
		    
		    foreach(SpeciesStats spst in stats)
		    {
		    	row = table.AddRow();
		    	if(spst.SpeciesName == "")
		    	{
		    		row.Cells[0].AddParagraph("Pending images");
		    		row.Cells[1].AddParagraph(spst.SpeciesPictures.ToString()).AddFormattedText();
		    		row.Cells[2].AddParagraph(spst.SpeciesCount.ToString());
		    	}
		    	else
		    	{
		    		row.Cells[0].AddParagraph(spst.SpeciesName);
		    		row.Cells[1].AddParagraph(spst.SpeciesPictures.ToString());
		    		row.Cells[2].AddParagraph(spst.SpeciesCount.ToString());
		    	}
		    	
		    }
    	} catch (Exception ex) {
    		throw ex;
    	}
    	
    	
    }
    
    public static void StatsByStations_Table(Document document, Project currentProject)
    {
    	try {
	    	General_queries prjq=new General_queries(currentProject);
	    	List<StationStats> stats = prjq.AllStatsByStation;
	    	
	    	document.LastSection.AddParagraph("Statistics by stations", "Heading2");
	
		    Table table = document.LastSection.AddTable();
		    table.Borders.Visible = true;
		    table.TopPadding = 5;
		    table.BottomPadding = 5;
		
		    
		    Column column = table.AddColumn();
		    column.Format.Alignment = ParagraphAlignment.Center;
		    
		    column = table.AddColumn(Unit.FromCentimeter(5));
		    column.Format.Alignment = ParagraphAlignment.Center;
		
		    column = table.AddColumn();
		    column.Format.Alignment = ParagraphAlignment.Center;
		
		    column = table.AddColumn();
		    column.Format.Alignment = ParagraphAlignment.Center;
		
		    table.Rows.Height = 20;
		
		    Row row = table.AddRow();
		    row.Shading.Color = Colors.PaleGoldenrod;
		    
		    row.Cells[0].AddParagraph().AddFormattedText("Station ID", TextFormat.Bold);
		    row.Cells[1].AddParagraph().AddFormattedText("Species", TextFormat.Bold);
		    row.Cells[2].AddParagraph().AddFormattedText("Valid pictures",TextFormat.Bold);
		    row.Cells[3].AddParagraph().AddFormattedText("Species count", TextFormat.Bold);
		    
		    
		    foreach(StationStats stst in stats)
		    {
		    	
	
		    	foreach(SpeciesStats spst in stst.SpeciesStats)
		    	{
		    		
					row = table.AddRow();
		    	
		    		row.Cells[0].AddParagraph(stst.StationID);
		    		row.Cells[0].MergeDown=stst.SpeciesStats.Count-1;
		    		
		    		if(spst.SpeciesName == "")
		    		{
		    			row.Cells[1].AddParagraph().AddFormattedText("Pending images",TextFormat.Italic);
		    			row.Cells[2].AddParagraph().AddFormattedText(spst.SpeciesPictures.ToString(),TextFormat.Italic);
		    			row.Cells[3].AddParagraph().AddFormattedText(spst.SpeciesCount.ToString(),TextFormat.Italic);
		    		}
		    		else
		    		{
		    			row.Cells[1].AddParagraph(spst.SpeciesName);
		    			row.Cells[2].AddParagraph(spst.SpeciesPictures.ToString());
		    			row.Cells[3].AddParagraph(spst.SpeciesCount.ToString());
		    		}
		    		
		    		
	
		    	}
		    	
	
		    }
    	} catch (Exception ex) {
    		throw ex;
    	}
    	
    }
    
    
    
    
    public static void DemonstrateSimpleTable(Document document)
    {
    	try {
    		document.LastSection.AddParagraph("Simple Tables", "Heading2");
    		
    		Table table = new Table();
    		table.Borders.Width = 0.75;
    		
    		Column column = table.AddColumn(Unit.FromCentimeter(2));
    		column.Format.Alignment = ParagraphAlignment.Center;
    		
    		table.AddColumn(Unit.FromCentimeter(5));
    		
    		Row row = table.AddRow();
    		row.Shading.Color = Colors.PaleGoldenrod;
    		Cell cell = row.Cells[0];
    		cell.AddParagraph("Itemus");
    		cell = row.Cells[1];
    		cell.AddParagraph("Descriptum");
    		
    		row = table.AddRow();
    		cell = row.Cells[0];
    		cell.AddParagraph("1");
    		cell = row.Cells[1];
    		cell.AddParagraph("Algo de texto");
    		
    		row = table.AddRow();
    		cell = row.Cells[0];
    		cell.AddParagraph("2");
    		cell = row.Cells[1];
    		cell.AddParagraph("Algo de texto");
    		
    		table.SetEdge(0, 0, 2, 3, Edge.Box, BorderStyle.Single, 1.5, Colors.Black);
    		
    		document.LastSection.Add(table);
    	} catch (Exception ex) {
    		throw ex;
    	}

    }

    public static void DemonstrateAlignment(Document document)
    {
    	try {
    		document.LastSection.AddParagraph("Cell Alignment", "Heading2");

    		Table table = document.LastSection.AddTable();
    		table.Borders.Visible = true;
    		table.Format.Shading.Color = Colors.LavenderBlush;
    		table.Shading.Color = Colors.Salmon;
    		table.TopPadding = 5;
    		table.BottomPadding = 5;

    		Column column = table.AddColumn();
    		column.Format.Alignment = ParagraphAlignment.Left;

    		column = table.AddColumn();
    		column.Format.Alignment = ParagraphAlignment.Center;
    		
    		column = table.AddColumn();
    		column.Format.Alignment = ParagraphAlignment.Right;

    		table.Rows.Height = 35;

    		Row row = table.AddRow();
    		row.VerticalAlignment = VerticalAlignment.Top;
    		row.Cells[0].AddParagraph("Text");
    		row.Cells[1].AddParagraph("Text");
    		row.Cells[2].AddParagraph("Text");

    		row = table.AddRow();
    		row.VerticalAlignment = VerticalAlignment.Center;
    		row.Cells[0].AddParagraph("Text");
    		row.Cells[1].AddParagraph("Text");
    		row.Cells[2].AddParagraph("Text");

    		row = table.AddRow();
    		row.VerticalAlignment = VerticalAlignment.Bottom;
    		row.Cells[0].AddParagraph("Text");
    		row.Cells[1].AddParagraph("Text");
    		row.Cells[2].AddParagraph("Text");
    	} catch (Exception ex) {
    		throw ex;
    	}
     
    }

    public static void DemonstrateCellMerge(Document document)
    {
    	try {
    		document.LastSection.AddParagraph("Cell Merge", "Heading2");

    		Table table = document.LastSection.AddTable();
    		table.Borders.Visible = true;
    		table.TopPadding = 5;
    		table.BottomPadding = 5;

    		Column column = table.AddColumn();
    		column.Format.Alignment = ParagraphAlignment.Left;

    		column = table.AddColumn();
    		column.Format.Alignment = ParagraphAlignment.Center;

    		column = table.AddColumn();
    		column.Format.Alignment = ParagraphAlignment.Right;

    		table.Rows.Height = 35;

    		Row row = table.AddRow();
    		row.Cells[0].AddParagraph("Merge Right");
    		row.Cells[0].MergeRight = 1;

    		row = table.AddRow();
    		row.VerticalAlignment = VerticalAlignment.Bottom;
    		row.Cells[0].MergeDown = 1;
    		row.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
    		row.Cells[0].AddParagraph("Merge Down");

    		table.AddRow();
    	} catch (Exception ex) {
    		throw ex;
    	}
     
    }
    
  }
}
