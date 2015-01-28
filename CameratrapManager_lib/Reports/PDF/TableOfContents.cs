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
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Fields;

namespace CameratrapManager_lib.Reports.PDF
{
	/// <summary>
	/// Description of TableOfContents.
	/// </summary>
  public class TableOfContents
  {
    /// <summary>
    /// Defines the cover page.
    /// </summary>
    public static void DefineTableOfContents(Document document)
    {
    	try {
	    	Section section = document.LastSection;
	
	    	section.AddPageBreak();
	    	Paragraph paragraph = section.AddParagraph("Table of Contents");
	    	paragraph.Format.Font.Size = 14;
	    	paragraph.Format.Font.Bold = true;
	    	paragraph.Format.SpaceAfter = 24;
	    	paragraph.Format.OutlineLevel = OutlineLevel.Level1;
	
	    	paragraph = section.AddParagraph();
	    	paragraph.Style = "TOC";
	    	Hyperlink hyperlink = paragraph.AddHyperlink("Paragraphs");
	    	hyperlink.AddText("Paragraphs\t");
	    	hyperlink.AddPageRefField("Paragraphs");
	
	    	paragraph = section.AddParagraph();
	    	paragraph.Style = "TOC";
	    	hyperlink = paragraph.AddHyperlink("Tables");
	    	hyperlink.AddText("Tables\t");
	    	hyperlink.AddPageRefField("Tables");
	
	    	paragraph = section.AddParagraph();
	    	paragraph.Style = "TOC";
	    	hyperlink = paragraph.AddHyperlink("Charts");
	    	hyperlink.AddText("Charts\t");
	    	hyperlink.AddPageRefField("Charts");
    	} catch (Exception ex) {
    		throw ex;
    	}
    	
    }
  }
}
