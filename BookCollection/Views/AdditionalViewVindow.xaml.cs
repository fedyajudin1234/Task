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
    /// Логика взаимодействия для AdditionalViewVindow.xaml
    /// </summary>
    public partial class AdditionalViewVindow : Window
    {
        public AdditionalViewVindow()
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Window_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
