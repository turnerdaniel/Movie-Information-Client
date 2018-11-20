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


    }
}
