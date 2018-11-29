using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace MovieDatabase
{
	/// <summary>
	/// Interaction logic for WishList.xaml
	/// </summary>
	public partial class WishList : Window
    {
        public WishList()
        {
            InitializeComponent();
        }

        private void WishListLoaded(object sender, RoutedEventArgs e)
        {
            lbWishlist.ItemsSource = MainWindow.wishList;
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

        private void DeactivateWindow(Window current)
        {
            current.Hide();
        }

        private void removeFromWish(object sender, RoutedEventArgs e)
        {
            //Get current selection
            Movie CurrentSelection = lbWishlist.SelectedItem as Movie;

            //Remove item from list
            MainWindow.wishList.Remove(CurrentSelection);
            removeFromFile(CurrentSelection);

            lbWishlist.ItemsSource = "";
            lbWishlist.ItemsSource = MainWindow.wishList;
        }

        private void removeFromFile(Movie mov)
        {
            List<string> file = File.ReadAllLines("wishlist.txt").ToList();
            file.Remove(mov.imdbID);          
            File.WriteAllLines("wishlist.txt", file.ToArray());
        }


    }
}
