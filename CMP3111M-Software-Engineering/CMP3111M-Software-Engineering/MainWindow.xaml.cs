using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CMP3111M_Software_Engineering
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
			// The following is an example of how to use the API class
			API api = new API();
			List<Movie> searchResults = api.getSearch("title", "Hello World"); // searches the OMDB API for 'Hello World' and returns a List of type Movie with data
			foreach (Movie thisMovie in searchResults)
			{
				MessageBox.Show(thisMovie.Title + " (" + thisMovie.Year + ") (" + thisMovie.Type + ") IMDB ID: " + thisMovie.imdbID + ", Poster URL: " + thisMovie.Poster);
			}
		}
	}

	
}
