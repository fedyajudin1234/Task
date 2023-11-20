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
using System.Windows.Shapes;

namespace BookCollection.Views
{
    /// <summary>
    /// Логика взаимодействия для AddNewBookWindow.xaml
    /// </summary>
    public partial class AddNewBookWindow : Window
    {
        public AddNewBookWindow()
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
            Genre_Combo_Box.ItemsSource = Enum.GetValues(typeof(Genre));
        }
    }
}
