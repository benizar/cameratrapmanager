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

namespace CameratrapManager_lib.Analysis.Queries
{
	/// <summary>
	/// Description of SpeciesStats.
	/// </summary>
	public class SpeciesStats
	{
		
		public SpeciesStats()
		{
		}
		
		public SpeciesStats(string speciesName, int speciesCount, int speciesPictures)
		{
			_speciesName=speciesName;
			_speciesCount=speciesCount;
			_speciesPictures=speciesPictures;
		}
		
		string _speciesName;
		int _speciesCount=0;
		int _speciesPictures=0;
		double[]_activityPatern=new double[23];
		
		
		public string SpeciesName {
			get { return _speciesName; }
			set { _speciesName = value; }
		}
		
		public int SpeciesCount {
			get { return _speciesCount; }
			set { _speciesCount = value; }
		}
		
		public int SpeciesPictures {
			get { return _speciesPictures; }
			set { _speciesPictures = value; }
		}
		
		public double[] ActivityPatern {
			get { return _activityPatern; }
			set { _activityPatern = value; }
		}
		
		
		
	}
}
