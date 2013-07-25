/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 12:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using AForge.Imaging;
using AForge.Imaging.Filters;

namespace CameratrapManager_lib.ImageProcessing
{
	/// <summary>
	/// Description of Preprocessing.
	/// </summary>
	public class OCR_Preprocessing
	{
		public OCR_Preprocessing()
		{
		}
		
		/// <summary>
		/// Apply corrections and crop a specific part of an image in order to perform OCR
		/// </summary>
		/// <param name="SourceImage"></param>
		/// <param name="rect"></param>
		/// <returns></returns>
		public static Bitmap PreprocessOCR(Bitmap SourceImage, Rectangle rect)
        {
			try {
				// binarization filtering sequence
	            FiltersSequence filter = new FiltersSequence(
	                new Crop(rect),
	                new Median(),
	                new ContrastCorrection(),
	                //new Mean(),
	                new AForge.Imaging.Filters.Blur(),
	                new GrayscaleBT709(),
	                //new Threshold(),
	                new Threshold(),
	                new Invert()
	                
	            );
	
	
	            // load image
	            Bitmap image = SourceImage;
	
	            // format image
	            AForge.Imaging.Image.Clone(image,image.PixelFormat);
	//            AForge.Imaging.Image.FormatImage(ref image);
	
	            // lock the source image
	            BitmapData sourceData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
	
	            // apply filters and binarize the image
	            UnmanagedImage binarySource = filter.Apply(new UnmanagedImage(sourceData));
	
	
	            Bitmap binarizedImage= binarySource.ToManagedImage();
	            
	
	            // unlock source image
	            image.UnlockBits(sourceData);
	
	            // dispose temporary binary source image
	            binarySource.Dispose();
	
	            return binarizedImage;
			} catch (Exception ex) {
				throw ex;
			}



        }//preprocess
		
		
		
		
	}
}
