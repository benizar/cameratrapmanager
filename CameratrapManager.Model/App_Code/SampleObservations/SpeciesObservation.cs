﻿//Camera Trap Manager. A C# desktop application for managing
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

namespace CameratrapManager.Model.SampleObservations
{
	/// <summary>
	/// Description of SpeciesObservation.
	/// </summary>
	/// 
	[Serializable]
	public class SpeciesObservation:Observation
	{
		public SpeciesObservation()
		{
			
		}
		
		public SpeciesObservation(string Name, string Value, int Count):base(Name,Value)
		{
			_count=Count;
		}
		
		int _count;
		
		
		public new string Value {
			get { return (string)_value; }
			set { _value = (string)value; }
		}
		
		public int Count {
			get { return (int)_count; }
			set { _count = (int)value; }
		}
		
		
	}
}
