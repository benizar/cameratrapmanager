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
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging;

namespace CameratrapManager.ImageProcessing
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
