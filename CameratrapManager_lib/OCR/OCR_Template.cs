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
