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
    public class AuthorViewModel: INotifyPropertyChanged
    {
        private List<Author> authorList = DataOperations.GetAllAuthors();

        public List<Author> AllAuthors
        {
            get { return authorList; }
            set
            {
                authorList = value;
                NotifyPropertyChanged("AllAuthors");
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

        #region Open Window
        private RelayCommand addNewAuthor;
        public RelayCommand AddNewAuthor
        {
            get{
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
