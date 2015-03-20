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

namespace CameratrapManager.Model.SampleObservations
{
	/// <summary>
	/// Description of Observation.
	/// </summary>
	/// 
	[Serializable]
	public class Observation
	{
		
		public Observation()
		{
			
		}
		
		
		public Observation(string Name, object Value)
		{
			this.BuildObservation(Name,Value);
		}
		
		
		string _name;
		protected object _value;
		
		
		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		
		public object Value {
			get { return _value; }
			set { _value = value; }
		}
		
		
		private void BuildObservation(string Name, object Value)
		{
			_name=Name;
			_value=Value;
		}
		
		internal virtual void DoOCR(string fullFilename)
		{
		}
		
	}
}
