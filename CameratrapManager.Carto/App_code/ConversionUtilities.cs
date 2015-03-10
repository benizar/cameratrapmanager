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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CameratrapManager.Carto
{
	/// <summary>
	/// Description of ConversionUtilities.
	/// </summary>
	public class ConversionUtilities
	{
		
		public static string SerializeBase64(object o)
		{
			try {
				// Serialize to a base 64 string
				byte[] bytes;
				long length = 0;
				MemoryStream ws = new MemoryStream();
				BinaryFormatter sf = new BinaryFormatter();
				sf.Serialize(ws, o);
				length = ws.Length;
				bytes = ws.GetBuffer();
				string encodedData = bytes.Length + ":" + Convert.ToBase64String(bytes, 0, bytes.Length, Base64FormattingOptions.None);
				return encodedData;
			} catch (Exception ex) {
				throw ex;
			}
		   
		}
		
		
		public static object DeserializeBase64(string s)
		{
			try {
				// We need to know the exact length of the string - Base64 can sometimes pad us by a byte or two
				int p = s.IndexOf(':');
				int length = Convert.ToInt32(s.Substring(0, p));
				
				// Extract data from the base 64 string!
				byte[] memorydata = Convert.FromBase64String(s.Substring(p + 1));
				MemoryStream rs = new MemoryStream(memorydata, 0, length);
				BinaryFormatter sf = new BinaryFormatter();
				object o = sf.Deserialize(rs);
				return o;
			} catch (Exception ex) {
				throw ex;
			}
		    
		}
		
		
		/// <summary>
		/// Provides a memory copy of an original image file
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static System.Drawing.Image NonLockingOpen(string filename)
		{
			try {
				System.Drawing.Image result;
				
				#region Save file to byte array
				
				long size = (new FileInfo(filename)).Length;
				FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				byte[] data = new byte[size];
				try {
					fs.Read(data, 0, (int)size);
				} finally {
					fs.Close();
					fs.Dispose();
				}
				
				#endregion
				
				#region Convert bytes to image
				
				MemoryStream ms = new MemoryStream();
				ms.Write(data, 0, (int)size);
				result = new Bitmap(ms);
				ms.Close();
				
				#endregion
				
				return result;
				
			} catch (Exception ex) {
				throw ex;
			}
			
		}
		
		
		public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
		{
			try {
				using (MemoryStream ms = new MemoryStream())
				{
					// Convert Image to byte[]
					image.Save(ms, format);
					byte[] imageBytes = ms.ToArray();
					
					// Convert byte[] to Base64 String
					string base64String = Convert.ToBase64String(imageBytes);
					return base64String;
				}
			} catch (Exception ex) {
				throw ex;
			}
			 
		}
		
		
		public static Image Base64ToImage(string base64String)
		{
			try {
				// Convert Base64 String to byte[]
				byte[] imageBytes = Convert.FromBase64String(base64String);
				MemoryStream ms = new MemoryStream(imageBytes, 0,
				                                   imageBytes.Length);
				
				// Convert byte[] to Image
				ms.Write(imageBytes, 0, imageBytes.Length);
				Image image = Image.FromStream(ms, true);
				ms.Close();
				return image;
			} catch (Exception ex) {
				throw ex;
			}
			 
		}
		
		
	}
}
