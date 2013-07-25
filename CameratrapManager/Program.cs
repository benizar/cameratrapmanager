/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 11:50
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace CameratrapManager
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			
			string ProjectsPath = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location)+ @"\\Projects\\";
			if(Directory.Exists(ProjectsPath)==false)
			{
				Directory.CreateDirectory(ProjectsPath);
			}
			
			Application.Run(new MainForm());
		}
		
	}
}
