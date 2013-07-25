/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 29/05/2011
 * Hora: 21:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;

using Fotofly;

namespace CameratrapManager_lib.OCR
{
	/// <summary>
	/// Description of OCR_Template.
	/// </summary>
	/// 
	[Serializable]
	public class OCR_Template
	{
		public OCR_Template()
		{
		}
		
		public OCR_Template(Image SampleImage)
		{
			
		}
		
		public OCR_Template(string nam, string cam, Rectangle rect, Size imgSize)
		{
			_name=nam;
			_cameraModel=cam;
			_OCRrect=rect;
			_imageSize=imgSize;
			
		}
		
		
		string _name;
		string _cameraModel;
		Rectangle _OCRrect;
		Size _imageSize;
		
		public string Name {
			get { return _name; }
			set { _name = value; }
		}

		public string CameraModel {
			get { return _cameraModel; }
			set { _cameraModel = value; }
		}

		public Rectangle OCRrect {
			get { return _OCRrect; }
			set { _OCRrect = value; }
		}

		public Size ImageSize {
			get { return _imageSize; }
			set { _imageSize = value; }
		}
		
		
	}
}
