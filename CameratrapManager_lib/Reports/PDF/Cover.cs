/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 15/06/2011
 * Hora: 14:30
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
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
