using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
	public class Movie // the movie class for containing information about a movie
	{ 
		public string Poster { get; set; } //image URL (.jpg)
		public string Title { get; set; }
		public string Year { get; set; } //string because some dates are ranges
		public string imdbID { get; set; } //format: tt1234567
		public string Type { get; set; }
	}
}
