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

using CameratrapManager.Model;


namespace CameratrapManager.Output.PDF
{
	/// <summary>
	/// Description of Paragraphs.
	/// </summary>
  public class Paragraphs
  {
    public static void Project_overview(Document document, Project currentProject)
    {
    	try {
    		Paragraph paragraph = document.LastSection.AddParagraph("Camera Trap Project Overview", "Heading1");
	      	paragraph.AddBookmark("Overview");
	      
	        document.LastSection.AddParagraph("Subject", "Heading2");
	    	paragraph = document.LastSection.AddParagraph();
	      	paragraph.Format.Alignment = ParagraphAlignment.Left;
	     	paragraph.AddText(currentProject.Subject);
	     	
	     	document.LastSection.AddParagraph("Description", "Heading2");
	    	paragraph = document.LastSection.AddParagraph();
	      	paragraph.Format.Alignment = ParagraphAlignment.Left;
	     	paragraph.AddText(currentProject.Description);
	     	
	     	document.LastSection.AddParagraph("Type of project", "Heading2");
	    	paragraph = document.LastSection.AddParagraph();
	      	paragraph.Format.Alignment = ParagraphAlignment.Left;
	     	paragraph.AddText(currentProject.Type);
    	} catch (Exception ex) {
    		throw ex;
    	}
    	
    	
      	
    }
    
    
    
    
    
    static void DemonstrateAlignment(Document document)
    {
    	try {
	      document.LastSection.AddParagraph("Alignment", "Heading2");
	
	      document.LastSection.AddParagraph("Left Aligned", "Heading3");
	
	      Paragraph paragraph = document.LastSection.AddParagraph();
	      paragraph.Format.Alignment = ParagraphAlignment.Left;
	      paragraph.AddText("Algo de texto");
	
	      document.LastSection.AddParagraph("Right Aligned", "Heading3");
	
	      paragraph = document.LastSection.AddParagraph();
	      paragraph.Format.Alignment = ParagraphAlignment.Right;
	      paragraph.AddText("Algo de texto");
	
	      document.LastSection.AddParagraph("Centered", "Heading3");
	
	      paragraph = document.LastSection.AddParagraph();
	      paragraph.Format.Alignment = ParagraphAlignment.Center;
	      paragraph.AddText("Algo de texto");
	
	      document.LastSection.AddParagraph("Justified", "Heading3");
	
	      paragraph = document.LastSection.AddParagraph();
	      paragraph.Format.Alignment = ParagraphAlignment.Justify;
	      paragraph.AddText("Algo de texto");
    	} catch (Exception ex) {
    		throw ex;
    	}
     
    }

    static void DemonstrateIndent(Document document)
    {
    	try {
	      	document.LastSection.AddParagraph("Indent", "Heading2");
	
	      	document.LastSection.AddParagraph("Left Indent", "Heading3");
	
		    Paragraph paragraph = document.LastSection.AddParagraph();
		    paragraph.Format.LeftIndent = "2cm";
		    paragraph.AddText("Algo de texto");
		
		    document.LastSection.AddParagraph("Right Indent", "Heading3");
		
		    paragraph = document.LastSection.AddParagraph();
		    paragraph.Format.RightIndent = "1in";
		    paragraph.AddText("Algo de texto");
		
		    document.LastSection.AddParagraph("First Line Indent", "Heading3");
		
		    paragraph = document.LastSection.AddParagraph();
		    paragraph.Format.FirstLineIndent = "12mm";
		    paragraph.AddText("Algo de texto");
		
		    document.LastSection.AddParagraph("First Line Negative Indent", "Heading3");
		
		    paragraph = document.LastSection.AddParagraph();
		    paragraph.Format.LeftIndent = "1.5cm";
		    paragraph.Format.FirstLineIndent = "-1.5cm";
		    paragraph.AddText("Algo de texto");
    	} catch (Exception ex) {
    		throw ex;
    	}
     
    }

    static void DemonstrateFormattedText(Document document)
    {
    	try {
	      document.LastSection.AddParagraph("Formatted Text", "Heading2");
	
	      //document.LastSection.AddParagraph("Left Aligned", "Heading3");
	
	      Paragraph paragraph = document.LastSection.AddParagraph();
	      paragraph.AddText("Text can be formatted ");
	      paragraph.AddFormattedText("bold", TextFormat.Bold);
	      paragraph.AddText(", ");
	      paragraph.AddFormattedText("italic", TextFormat.Italic);
	      paragraph.AddText(", or ");
	      paragraph.AddFormattedText("bold & italic", TextFormat.Bold | TextFormat.Italic);
	      paragraph.AddText(".");
	      paragraph.AddLineBreak();
	      paragraph.AddText("You can set the ");
	      FormattedText formattedText = paragraph.AddFormattedText("size ");
	      formattedText.Size = 15;
	      paragraph.AddText("the ");
	      formattedText = paragraph.AddFormattedText("color ");
	      formattedText.Color = Colors.Firebrick;
	      paragraph.AddText("the ");
	      paragraph.AddFormattedText("font", new Font("Verdana"));
	      paragraph.AddText(".");
	      paragraph.AddLineBreak();
	      paragraph.AddText("You can set the ");
	      formattedText = paragraph.AddFormattedText("subscript");
	      formattedText.Subscript = true;
	      paragraph.AddText(" or ");
	      formattedText = paragraph.AddFormattedText("superscript");
	      formattedText.Superscript = true;
	      paragraph.AddText(".");
    	} catch (Exception ex) {
    		throw ex;
    	}
      
    }

    static void DemonstrateBordersAndShading(Document document)
    {
    	try {
	      document.LastSection.AddPageBreak();
	      document.LastSection.AddParagraph("Borders and Shading", "Heading2");
	
	      document.LastSection.AddParagraph("Border around Paragraph", "Heading3");
	
	      Paragraph paragraph = document.LastSection.AddParagraph();
	      paragraph.Format.Borders.Width = 2.5;
	      paragraph.Format.Borders.Color = Colors.Navy;
	      paragraph.Format.Borders.Distance = 3;
	      paragraph.AddText("Algo de texto");
	
	      document.LastSection.AddParagraph("Shading", "Heading3");
	
	      paragraph = document.LastSection.AddParagraph();
	      paragraph.Format.Shading.Color = Colors.LightCoral;
	      paragraph.AddText("Algo de texto");
	
	      document.LastSection.AddParagraph("Borders & Shading", "Heading3");
	
	      paragraph = document.LastSection.AddParagraph();
	      paragraph.Style = "TextBox";
	      paragraph.AddText("Algo de texto");

    	} catch (Exception ex) {
    		throw ex;
    	}
    	
     
    }
  }
}
