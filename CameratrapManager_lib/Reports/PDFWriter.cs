/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 15/06/2011
 * Hora: 15:24
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

using CameratrapManager_lib.CameratrapModel;
using CameratrapManager_lib.Reports.PDF;

namespace CameratrapManager_lib.Reports
{
	/// <summary>
	/// Description of PDFWriter.
	/// </summary>
	public class PDFWriter
	{
		public PDFWriter(Project currentProject, string PDFfilename)
		{
			WritePDF(currentProject, PDFfilename);
		}
		
		private void WritePDF(Project currentProject, string PDFfilename)
		{
			try {
				// Create a MigraDoc document
				Document document = Documents.CreateDocument(currentProject);
				
				PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
				renderer.Document = document;
				
				renderer.RenderDocument();
				
				// Save the document...
				renderer.PdfDocument.Save(PDFfilename);
				//Start a viewer.
				Process.Start(PDFfilename);
			} catch (Exception ex) {
				throw ex;
			}
			
		}
	}
}
