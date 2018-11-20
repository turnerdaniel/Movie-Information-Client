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
        API omdb = new API();
		List<Movie> movies = new List<Movie>();
        public static List<Movie> wishList = new List<Movie>();
        WishList wishListPage = new WishList();
        


        public MainWindow()
		{
            InitializeComponent();
        }

        public void Search_OnClick(object sender,RoutedEventArgs e)
        {
			string searchType = cmbSearchType.Text;
			//reset movie output
			lbMovies.ItemsSource = "";

			movies = omdb.search(searchType, SearchBar.Text);

			lbMovies.ItemsSource = movies;
		}


        private void DeactivateWindow(Window current)
        {
            current.Hide();   

        }

            
        private void SearchInt(object sender, RoutedEventArgs e)
        {
            DeactivateWindow(this);
            MainWindow homepage = new MainWindow();
            homepage.Show();
            
        }

        private void WishInt(object sender, RoutedEventArgs e)
        {
            DeactivateWindow(this);
            WishList wishpage = new WishList();
            wishpage.Show();

        }

        private void AddToWish(object sender, RoutedEventArgs e)
        {

            
            //Add to list 
            Movie CurrentSelection = lbMovies.SelectedItem as Movie;

            //Add to list 
            wishList.Add(CurrentSelection);


            //wishListPage.lbWishList.ItemsSource = wishList;








        }
    }
}
