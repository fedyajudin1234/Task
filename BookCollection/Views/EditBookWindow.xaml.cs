﻿using BookCollection.Models;
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
    /// Логика взаимодействия для EditBookWindow.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        public EditBookWindow(Book book)
        {
            InitializeComponent();
            DataContext = new ModelsViewModel();
            ModelsViewModel.SelectedBook = book;
            ModelsViewModel.Book_Name = book.Book_Name;
            ModelsViewModel.Year = book.Year;
            ModelsViewModel.Genre = book.Genre;
            ModelsViewModel.Author = book.Author;
            Genre_Combo_Box.ItemsSource = Enum.GetValues(typeof(Genre));
        }
    }
}
