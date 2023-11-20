using BookCollection.Models;
using BookCollection.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookCollection.ViewModels
{
    public class BookViewModel: INotifyPropertyChanged
    {
        private List<Book> bookList = DataOperations.GetAllBooks();

        public List<Book> AllBooks
        {
            get { 
                return bookList; 
            }
            set
            {
                bookList = value;
                NotifyPropertyChanged("AllBooks");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private RelayCommand addNewBook;
        public RelayCommand AddNewBook
        {
            get
            {
                return addNewBook ?? new RelayCommand(obj =>
                {
                    OpenNewAddBookWindow();
                });
            }
        }

        #region Add Book
        private void OpenNewAddBookWindow()
        {
            AddNewBookWindow addNewBookWindow = new AddNewBookWindow();
            addNewBookWindow.Owner = App.Current.MainWindow;
            addNewBookWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addNewBookWindow.ShowDialog();
        }
        #endregion

        #region Edit Book
        private void OpenEditBookWindow(Book book)
        {
            EditBookWindow editBookWindow = new EditBookWindow(book);
            editBookWindow.Owner = App.Current.MainWindow;
            editBookWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editBookWindow.ShowDialog();
        }
        #endregion

        private List<Author> authorList = DataOperations.GetAllAuthors();

        public List<Author> AllAuthors
        {
            get { return authorList; }
            set
            {
                authorList = value;
                NotifyPropertyChangedAuthor("AllAuthors");
            }
        }

        public event PropertyChangedEventHandler? PropertyChangedAuthor;

        private void NotifyPropertyChangedAuthor(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Open Window
        private RelayCommand addNewAuthor;
        public RelayCommand AddNewAuthor
        {
            get
            {
                return addNewAuthor ?? new RelayCommand(obj =>
                {
                    OpenNewAddAuthorWindow();
                });
            }
        }
        #endregion

        #region Add Author
        private void OpenNewAddAuthorWindow()
        {
            AddNewAuthorWindow addNewAuthorWindow = new AddNewAuthorWindow();
            addNewAuthorWindow.Owner = App.Current.MainWindow;
            addNewAuthorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addNewAuthorWindow.ShowDialog();
        }
        #endregion

        #region Edit Author
        private void OpenEditAddAuthorWindow(Author author)
        {
            EditAuthorWindow editAuthorWindow = new EditAuthorWindow(author);
            editAuthorWindow.Owner = App.Current.MainWindow;
            editAuthorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editAuthorWindow.ShowDialog();
        }
        #endregion
    }
}
