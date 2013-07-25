/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 10/06/2011
 * Hora: 19:34
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging;

namespace CameratrapManager_lib.ImageProcessing
{
	/// <summary>
	/// Description of Main_processing.
	/// </summary>
	public class Main_processing
	{
		public Main_processing()
		{
		}
		
		public static System.Drawing.Image ResizeImage(System.Drawing.Image SourceImage)
		{
			try {
//				// binarization filtering sequence
//	            FiltersSequence filter = new FiltersSequence(
//	                new Crop(rect),
//	                new Median(),
//	                new ContrastCorrection(),
//	                //new Mean(),
//	                new AForge.Imaging.Filters.Blur(),
//	                new GrayscaleBT709(),
//	                //new Threshold(),
//	                new Threshold(),
//	                new Invert()
//	                
//	            );
	
	
	            // load image
	            Bitmap image = (Bitmap)SourceImage;
	
	            // format image
	            AForge.Imaging.Image.Clone(image,image.PixelFormat);
	//            AForge.Imaging.Image.FormatImage(ref image);
	
	            // lock the source image
	            BitmapData sourceData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
	
	            // create filter
	            ResizeBilinear filter = new ResizeBilinear( image.Width/2, image.Height/2 );
	            // apply the filter
//	            Bitmap newImage = filter.Apply( image );
	            
	            UnmanagedImage binarySource = filter.Apply(new UnmanagedImage(sourceData));
	
	
	            Bitmap binarizedImage= binarySource.ToManagedImage();
	            
	
	            // unlock source image
	            image.UnlockBits(sourceData);
	
	            // dispose temporary binary source image
	            binarySource.Dispose();
	
	            System.Drawing.Image img= ( System.Drawing.Image)binarizedImage;
	            
	            return img;

			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		
		
	}
}
