using BookCollection.ViewModels;
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

namespace BookCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllAuthorsView;
        public static ListView AllBooksView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
            AllAuthorsView = AllAuthors_ListView;
            AllBooksView = AllBooks_ListView;
        }

        private void LanguageBox_Checked(object sender, RoutedEventArgs e)
        {
            if (LanguageBox.IsChecked == true)
            {
                
            }
        }
    }
}
