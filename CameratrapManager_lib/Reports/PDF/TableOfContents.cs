/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 15/06/2011
 * Hora: 15:14
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
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
