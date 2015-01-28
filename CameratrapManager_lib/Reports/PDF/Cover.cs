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
using System.Resources;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;

using CameratrapManager_lib.CameratrapModel;


namespace CameratrapManager_lib.Reports.PDF
{
	/// <summary>
	/// Description of Cover.
	/// </summary>
  public class Cover
  {
    /// <summary>
    /// Defines the cover page.
    /// </summary>
    public static void DefineCover(Document document, Project currentProject)
    {
    	try {
    		Section section = document.AddSection();

		    Paragraph paragraph = section.AddParagraph();
		    paragraph.Format.SpaceAfter = "3cm";
				    
		    Image image = section.AddImage(System.IO.Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location)+@"\\logo.jpg");
		    image.Width = "6cm";
		
		    paragraph = section.AddParagraph("Report generated using Cameratrap Manager\nfor the project:\n"+currentProject.Name);
		    paragraph.Format.Font.Size = 16;
		    paragraph.Format.Font.Color = Colors.DarkRed;
		    paragraph.Format.SpaceBefore = "6cm";
		    paragraph.Format.SpaceAfter = "3cm";
		
		    paragraph=section.AddParagraph("Creation date: " + currentProject.StartDate.ToString());
		    paragraph=section.AddParagraph("Last modified: " + currentProject.CompletionDate.ToString());
		      
		    paragraph = section.AddParagraph("Rendering date: ");
		    paragraph.AddDateField();
    	} catch (Exception ex) {
    		throw ex;
    	}
    	
     
    }
  }
}
