using BookCollection.Models;
using BookCollection.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BookCollection.ViewModels
{
    public class ModelsViewModel: INotifyPropertyChanged
    {
        private List<Book> bookList = DataOperations.GetAllBooks();
        private List<Author> authorList = DataOperations.GetAllAuthors();

        #region Add comand for Author
        //свойства для автора
        public static string Name { get; set; }
        public static string Surname { get; set; }

        private RelayCommand addNewAuthor;
        public RelayCommand AddNewAuthor
        {
            get
            {
                return addNewAuthor ?? new RelayCommand(obj =>
                {
                    var regexItem = new Regex("[a-zA-Z]");
                    Window window = obj as Window;

                    if (regexItem.IsMatch(Name) && regexItem.IsMatch(Surname))
                    {
                        DataOperations.CreateAuthor(Name, Surname);
                        UpdateAllData();
                        ShowAdditionalWindow();
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный ввод");
                    }
                });
            }
        }
        #endregion

        #region Add comand for Book
        //свойства для автора
        public static string Book_Name { get; set; }
        public static int Year { get; set; }
        public static Genre Genre { get; set; }
        public static Author? Author { get; set; }

        private RelayCommand addNewBook;
        public RelayCommand AddNewBook
        {
            get
            {
                return addNewBook ?? new RelayCommand(obj =>
                {
                    var regexBookName = new Regex("[a-zA-Z0-9]");
                    //var regexYear = new Regex("[^0-9]+");
                    Window window = obj as Window;
                    string yearString = Year.ToString();
                    bool isInt = Int32.TryParse(yearString, out int value);
                    if (regexBookName.IsMatch(Book_Name) && isInt && Author != null && Genre != null)
                    {
                        DataOperations.CreateBook(Book_Name, Year, Genre, Author);
                        UpdateAllData();
                        ShowAdditionalWindow();
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный ввод");
                    }
                });
            }
        }
        #endregion

        public static Author SelectedAuthor { get; set; }
        public static Book SelectedBook { get; set; }
        public static TabItem SelectedTabItem { get; set; }


        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    if(SelectedTabItem.Name == "AuthorTab" && SelectedAuthor != null)
                    {
                        DataOperations.DeleteAuthor(SelectedAuthor);
                        UpdateAllData();
                    }else if(SelectedTabItem.Name == "BookTab" && SelectedBook != null)
                    {
                        DataOperations.DeleteBook(SelectedBook);
                        UpdateAllData();
                    }
                    else
                    {
                        MessageBox.Show("Ничего не выбрано");
                    }
                    SetNullProperties();
                });
            }
        }

        private RelayCommand editItem;
        public RelayCommand EditItem
        {
            get
            {
                return editItem ?? new RelayCommand(obj =>
                {
                    if (SelectedTabItem.Name == "AuthorTab" && SelectedAuthor != null)
                    {
                        DataOperations.GetAuthor = SelectedAuthor;
                        //DataOperations.DeleteAuthor(SelectedAuthor);
                        OpenEditAddAuthorWindow(SelectedAuthor);
                        //UpdateAllData();
                    }
                    else if (SelectedTabItem.Name == "BookTab" && SelectedBook != null)
                    {
                        DataOperations.GetBook = SelectedBook;
                        //DataOperations.DeleteBook(SelectedBook);
                        OpenEditBookWindow(SelectedBook);
                        //UpdateAllData();
                    }
                    else
                    {
                        MessageBox.Show("Ничего не выбрано");
                    }
                });
            }
        }

        private RelayCommand addInXMLItem;
        public RelayCommand AddInXMLItem
        {
            get
            {
                return addInXMLItem ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedTabItem.Name == "AuthorTab")
                    {
                        DataOperations.AddAuthorInXML(DataOperations.GetAuthor);
                        window.Close();
                    }
                    else if (SelectedTabItem.Name == "BookTab")
                    {
                        DataOperations.AddBookInXML(DataOperations.GetBook);
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ничего не выбрано");
                    }
                    SetNullProperties();
                });
            }
        }

        private RelayCommand addInJSONItem;
        public RelayCommand AddInJSONItem
        {
            get
            {
                return addInJSONItem ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedTabItem.Name == "AuthorTab")
                    {
                        
                        DataOperations.AddAuthorInJSON(DataOperations.GetAuthor);
                        window.Close();
                    }
                    else if (SelectedTabItem.Name == "BookTab")
                    {
                        DataOperations.AddBookInJSON(DataOperations.GetBook);
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ничего не выбрано");
                    }
                    SetNullProperties();
                });
            }
        }

        private RelayCommand addInTextItem;
        public RelayCommand AddInTextItem
        {
            get
            {
                return addInTextItem ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedTabItem.Name == "AuthorTab")
                    {

                        DataOperations.AddAuthorInText(DataOperations.GetAuthor);
                        window.Close();
                    }
                    else if (SelectedTabItem.Name == "BookTab")
                    {
                        DataOperations.AddBookInText(DataOperations.GetBook);
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ничего не выбрано");
                    }
                    SetNullProperties();
                });
            }
        }

        #region Book

        public List<Book> AllBooks
        {
            get
            {
                return bookList;
            }
            set
            {
                bookList = value;
                NotifyPropertyChangedBook("AllBooks");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChangedBook(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private RelayCommand openNewBook;
        public RelayCommand OpenNewBook
        {
            get
            {
                return openNewBook ?? new RelayCommand(obj =>
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

        private RelayCommand updateBook;
        public RelayCommand UpdateBook
        {
            get
            {
                return updateBook ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if (SelectedBook != null && Author != null)
                    {
                        DataOperations.EditBook(SelectedBook, Book_Name, Year, Genre, Author);
                        UpdateAllData();
                        SetNullProperties();
                        ShowAdditionalWindow();
                        window.Close();
                    }
                });
            }
        }

        private void OpenEditBookWindow(Book book)
        {
            EditBookWindow editBookWindow = new EditBookWindow(book);
            editBookWindow.Owner = App.Current.MainWindow;
            editBookWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editBookWindow.ShowDialog();
        }
        #endregion
        #endregion

        #region Author

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
        private RelayCommand openNewAuthor;
        public RelayCommand OpenNewAuthor
        {
            get
            {
                return openNewAuthor ?? new RelayCommand(obj =>
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
        #endregion

        #region UpdateView
        private void SetNullProperties()
        {
            Name = null;
            Surname = null;
            Book_Name = null;
            Year = 0;
            Genre = 0;
            Author = null;
        }

        private void UpdateAllData()
        {
            UpdateAllAuthors();
            UpdateAllBooks();
        }

        private void UpdateAllAuthors()
        {
            AllAuthors = DataOperations.GetAllAuthors();
            MainWindow.AllAuthorsView.ItemsSource = null;
            MainWindow.AllAuthorsView.Items.Clear();
            MainWindow.AllAuthorsView.ItemsSource = AllAuthors;
            MainWindow.AllAuthorsView.Items.Refresh();
        }

        private void UpdateAllBooks()
        {
            AllBooks = DataOperations.GetAllBooks();
            MainWindow.AllBooksView.ItemsSource = null;
            MainWindow.AllBooksView.Items.Clear();
            MainWindow.AllBooksView.ItemsSource = AllBooks;
            MainWindow.AllBooksView.Items.Refresh();
        }
        #endregion

        #region Edit Author
        private RelayCommand updateAuthor;
        public RelayCommand UpdateAuthor
        {
            get
            {
                return updateAuthor ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    if(SelectedAuthor != null)
                    {
                        DataOperations.EditAuthor(SelectedAuthor, Name, Surname);
                        UpdateAllData();
                        SetNullProperties();
                        ShowAdditionalWindow();
                        window.Close();
                    }
                });
            }
        }
        #endregion

        private bool ShowAdditionalWindow()
        {
            AdditionalViewVindow additionalViewVindow = new AdditionalViewVindow();
            additionalViewVindow.Owner = App.Current.MainWindow;
            additionalViewVindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            additionalViewVindow.ShowDialog();
            return true;
        }
    }
}
