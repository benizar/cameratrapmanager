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
