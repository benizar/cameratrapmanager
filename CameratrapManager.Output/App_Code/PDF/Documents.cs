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
using System.Diagnostics;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

using CameratrapManager.Model;


namespace CameratrapManager.Output.PDF
{
	/// <summary>
	/// Description of Documents.
	/// </summary>
  class Documents
  {
    public static Document CreateDocument(Project currentProject)
    {
    	try {
	      // Create a new MigraDoc document
	      Document document = new Document();
	      document.Info.Title = "Cameratrap Manager Report for "+currentProject.Name;
	      document.Info.Subject = currentProject.Subject;
	      document.Info.Author = currentProject.Creator;
	
	      Styles.DefineStyles(document);
	
	      Cover.DefineCover(document, currentProject);
	//      TableOfContents.DefineTableOfContents(document);
	
	      DefineContentSection(document, currentProject);
	
	      Paragraphs.Project_overview(document, currentProject);
	      Tables.DefineTables(document, currentProject);
	      Charts.DefineCharts(document, currentProject);
	
	      return document;
    	} catch (Exception ex) {
    		throw ex;
    	}
      
    }

    /// <summary>
    /// Defines page setup, headers, and footers.
    /// </summary>
    static void DefineContentSection(Document document, Project currentProject)
    {
    	try {
    	  Section section = document.AddSection();
	      section.PageSetup.OddAndEvenPagesHeaderFooter = true;
	      section.PageSetup.StartingNumber = 1;
	
	      HeaderFooter header = section.Headers.Primary;
	      header.AddParagraph(currentProject.Name);
	      
	      header = section.Headers.EvenPage;
	      header.AddParagraph(currentProject.Name);
	
	      // Create a paragraph with centered page number. See definition of style "Footer".
	      Paragraph paragraph = new Paragraph();
	      paragraph.AddTab();
	      paragraph.AddPageField();
	
	      // Add paragraph to footer for odd pages.
	      section.Footers.Primary.Add(paragraph);
	      // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
	      // not belong to more than one other object. If you forget cloning an exception is thrown.
	      section.Footers.EvenPage.Add(paragraph.Clone());
    	} catch (Exception ex) {
    		throw ex;
    	}
     
    }
  }
}
