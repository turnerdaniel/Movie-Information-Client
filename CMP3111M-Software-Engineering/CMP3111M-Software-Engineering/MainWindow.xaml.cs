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

namespace MovieDatabase
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        API api = new API();
        
        public MainWindow()
		{
            InitializeComponent();
            

            //for (int i = 0; i < length; i++)
            //{
              //  movie_data.Add();

          //  }
           // lvDataBinding.ItemsSource = items;


            

        }

        public string Get_SearchBar_Data()
        {
            TextBox search = (TextBox)this.FindName("SearchBar");


       
            return search.Text;


        }

        public void searchAndDisplay()
        {

            List<Movie> searchResults = api.getSearch("title", Get_SearchBar_Data());

           
            apiData.ItemsSource = searchResults;

            //Movie movie = new Movie();
            //movie.Title = node.Attributes["Title"].Value;
            //movie.Year = node.Attributes["Year"].Value;
            //movie.imdbID = node.Attributes["imdbID"].Value;
            //movie.Type = node.Attributes["Type"].Value;
            //movie.Poster = node.Attributes["Poster"].Value;



        }



        public void Search_OnClick(object sender,RoutedEventArgs e)
        {
            
            searchAndDisplay();



        }

        
    }
}
