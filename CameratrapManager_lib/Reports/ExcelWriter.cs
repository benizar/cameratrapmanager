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
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CameratrapManager_lib.Reports
{
    /// <summary>
    /// Produces Excel file without using Excel
    /// </summary>
    public class ExcelWriter
    {
        private Stream stream;
        private BinaryWriter writer;

        private ushort[] clBegin = { 0x0809, 8, 0, 0x10, 0, 0 };
        private ushort[] clEnd = { 0x0A, 00 };


        private void WriteUshortArray(ushort[] value)
        {
            for (int i = 0; i < value.Length; i++)
                writer.Write(value[i]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelWriter"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public ExcelWriter(Stream stream)
        {
            this.stream = stream;
            writer = new BinaryWriter(stream);
        }

        /// <summary>
        /// Writes the text cell value.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="col">The col.</param>
        /// <param name="value">The string value.</param>
        public void WriteCell(int row, int col, string value)
        {
            ushort[] clData = { 0x0204, 0, 0, 0, 0, 0 };
            int iLen = value.Length;
            byte[] plainText = Encoding.ASCII.GetBytes(value);
            clData[1] = (ushort)(8 + iLen);
            clData[2] = (ushort)row;
            clData[3] = (ushort)col;
            clData[5] = (ushort)iLen;
            WriteUshortArray(clData);
            writer.Write(plainText);
        }

        /// <summary>
        /// Writes the integer cell value.
        /// </summary>
        /// <param name="row">The row number.</param>
        /// <param name="col">The column number.</param>
        /// <param name="value">The value.</param>
        public void WriteCell(int row, int col, int value)
        {
            ushort[] clData = { 0x027E, 10, 0, 0, 0 };
            clData[2] = (ushort)row;
            clData[3] = (ushort)col;
            WriteUshortArray(clData);
            int iValue = (value << 2) | 2;
            writer.Write(iValue);
        }

        /// <summary>
        /// Writes the double cell value.
        /// </summary>
        /// <param name="row">The row number.</param>
        /// <param name="col">The column number.</param>
        /// <param name="value">The value.</param>
        public void WriteCell(int row, int col, double value)
        {
            ushort[] clData = { 0x0203, 14, 0, 0, 0 };
            clData[2] = (ushort)row;
            clData[3] = (ushort)col;
            WriteUshortArray(clData);
            writer.Write(value);
        }

        /// <summary>
        /// Writes the empty cell.
        /// </summary>
        /// <param name="row">The row number.</param>
        /// <param name="col">The column number.</param>
        public void WriteCell(int row, int col)
        {
            ushort[] clData = { 0x0201, 6, 0, 0, 0x17 };
            clData[2] = (ushort)row;
            clData[3] = (ushort)col;
            WriteUshortArray(clData);
        }

        /// <summary>
        /// Must be called once for creating XLS file header
        /// </summary>
        public void BeginWrite()
        {
            WriteUshortArray(clBegin);
        }

        /// <summary>
        /// Ends the writing operation, but do not close the stream
        /// </summary>
        public void EndWrite()
        {
            WriteUshortArray(clEnd);
            writer.Flush();
        }
    }
}
