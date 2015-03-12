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
using System.Windows.Forms;
using System.Globalization;

namespace CameratrapManager.Utilities
{
	/// <summary>
	/// Description of NumericTextBox.
	/// </summary>
	public class NumericTextBox : TextBox
	{
	    bool allowSpace = false;
	
	    // Restricts the entry of characters to digits (including hex), the negative sign,
	    // the decimal point, and editing keystrokes (backspace).
	    protected override void OnKeyPress(KeyPressEventArgs e)
	    {
	        base.OnKeyPress(e);
	
	        NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
	        string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
	        string groupSeparator = numberFormatInfo.NumberGroupSeparator;
	        string negativeSign = numberFormatInfo.NegativeSign;
	
	        string keyInput = e.KeyChar.ToString();
	
	        if (Char.IsDigit(e.KeyChar))
	        {
	            // Digits are OK
	        }
	        else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
	         keyInput.Equals(negativeSign))
	        {
	            // Decimal separator is OK
	        }
	        else if (e.KeyChar == '\b')
	        {
	            // Backspace key is OK
	        }
	        //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
	        //    {
	        //     // Let the edit control handle control and alt key combinations
	        //    }
	        else if (this.allowSpace && e.KeyChar == ' ')
	        {
	
	        }
	        else
	        {
	            // Swallow this invalid key and beep
	            e.Handled = true;
	            //    MessageBeep();
	        }
	    }
	
	    public int IntValue
	    {
	        get
	        {
	            return Int32.Parse(this.Text);
	        }
	    }
	
	    public decimal DecimalValue
	    {
	        get
	        {
	            return Decimal.Parse(this.Text);
	        }
	    }
	
	    public bool AllowSpace
	    {
	        set
	        {
	            this.allowSpace = value;
	        }
	
	        get
	        {
	            return this.allowSpace;
	        }
	    }
	}

}
