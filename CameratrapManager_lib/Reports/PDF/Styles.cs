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
using MigraDoc.DocumentObjectModel;

namespace CameratrapManager_lib.Reports.PDF
{
	/// <summary>
	/// Description of Styles.
	/// </summary>
  public class Styles
  {
    /// <summary>
    /// Defines the styles used in the document.
    /// </summary>
    public static void DefineStyles(Document document)
    {
    	try {
    		// Get the predefined style Normal.
	    	Style style = document.Styles["Normal"];
	    	// Because all styles are derived from Normal, the next line changes the
	    	// font of the whole document. Or, more exactly, it changes the font of
	    	// all styles and paragraphs that do not redefine the font.
	    	style.Font.Name = "Times New Roman";
	
	    	// Heading1 to Heading9 are predefined styles with an outline level. An outline level
	    	// other than OutlineLevel.BodyText automatically creates the outline (or bookmarks)
	    	// in PDF.
	
	    	style = document.Styles["Heading1"];
	    	style.Font.Name = "Tahoma";
	    	style.Font.Size = 14;
	    	style.Font.Bold = true;
	    	style.Font.Color = Colors.DarkBlue;
	    	style.ParagraphFormat.PageBreakBefore = true;
	    	style.ParagraphFormat.SpaceAfter = 6;
	
	    	style = document.Styles["Heading2"];
	    	style.Font.Size = 12;
	    	style.Font.Bold = true;
	    	style.ParagraphFormat.PageBreakBefore = false;
	    	style.ParagraphFormat.SpaceBefore = 6;
	    	style.ParagraphFormat.SpaceAfter = 6;
	
	    	style = document.Styles["Heading3"];
	    	style.Font.Size = 10;
	    	style.Font.Bold = true;
	    	style.Font.Italic = true;
	    	style.ParagraphFormat.SpaceBefore = 6;
	    	style.ParagraphFormat.SpaceAfter = 3;
	
	    	style = document.Styles[StyleNames.Header];
	    	style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);
	
	    	style = document.Styles[StyleNames.Footer];
	    	style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);
	
	    	// Create a new style called TextBox based on style Normal
	    	style = document.Styles.AddStyle("TextBox", "Normal");
	    	style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
	    	style.ParagraphFormat.Borders.Width = 2.5;
	    	style.ParagraphFormat.Borders.Distance = "3pt";
	    	//TODO: Colors
	    	style.ParagraphFormat.Shading.Color = Colors.SkyBlue;
	
	    	// Create a new style called TOC based on style Normal
	    	style = document.Styles.AddStyle("TOC", "Normal");
	    	style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
	    	style.ParagraphFormat.Font.Color = Colors.Blue;
    	} catch (Exception ex) {
    		throw ex;
    	}
	    
    }
  }
}
