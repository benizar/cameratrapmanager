/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 15/06/2011
 * Hora: 14:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
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
