using BookCollection.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace BookCollection
{
    public static class DataOperations
    {

        //List<Book> bookList = new List<Book>();

        //добавление книги
        public static void CreateBook(string book_name, int year, Genre genre, Author author)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                bool isBookExist = applicationContext.Books.Any(b => b.Book_Name == book_name
                && b.Year == year
                && b.Genre == genre &&
                b.AuthorId == author.Id);
                if (isBookExist)
                {
                    MessageBox.Show("Такая запись уже существует");
                }
                else
                {
                    Book book = new Book()
                    {
                        Book_Name = book_name,
                        Year = year,
                        Genre = genre,
                        AuthorId = author.Id
                    };
                    applicationContext.Add(book);
                    applicationContext.SaveChanges();
                    GetBook = book;
                    //MessageBox.Show("Книга успешно добавлена");
                }
            }
        }

        //удаление книги
        public static void DeleteBook(Book book)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                applicationContext.Books.Remove(book);
                applicationContext.SaveChanges();
                MessageBox.Show("Книга успешно удалена");
            }
        }

        //изменение книги
        public static void EditBook(Book oldBook, string new_book_name, int new_year, Genre new_genre, Author new_author)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                var book = applicationContext.Books.FirstOrDefault(b => b.Id == oldBook.Id);
                book.Book_Name = new_book_name;
                book.Year = new_year;
                book.Genre = new_genre;
                book.AuthorId = new_author.Id;
                applicationContext.SaveChanges();
                //MessageBox.Show("Книга успешно изменена");
            }
        }

        //все книги
        public static List<Book> GetAllBooks()
        {
            //List<Book> bookList = new List<Book>();
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                /*if(applicationContext.Books != null)
                {
                    var books = applicationContext.Books.ToList();
                    return books;
                }*/
                var books = applicationContext.Books.ToList();
                return books;
            }
        }

        public static Book? GetBook { get; set; }

        public static void AddBookInXML(Book book)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book));
            using(FileStream fileStream = new FileStream("Book.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, book);
            }
        }

        public static void AddBookInJSON(Book book)
        {
            using (FileStream fileStream = new FileStream("BookJson.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fileStream, book);
            }
        }

        public static void AddBookInText(Book book)
        {
            string[] strings = { book.Book_Name, book.Year.ToString(), book.Genre.ToString(), book.AuthorId.ToString() };
            File.WriteAllLines("BookText.txt", strings);
        }

        //добавление автора
        public static void CreateAuthor(string author_name, string author_surname)
        {
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                bool isAuthorExist = applicationContext.Authors.Any(a => a.Name == author_name && a.Surname == author_surname);
                if (isAuthorExist)
                {
                    MessageBox.Show("Такая запись уже существует");
                }
                else
                {
                    Author author = new Author()
                    {
                        Name = author_name,
                        Surname = author_surname
                    };
                    applicationContext.Add(author);
                    applicationContext.SaveChanges();
                    GetAuthor = author;
                    //MessageBox.Show("Автор успешно добавлен");
                }
            }
        }

        //удаление автора
        public static void DeleteAuthor(Author author)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                applicationContext.Authors.Remove(author);
                applicationContext.SaveChanges();
            }
            //MessageBox.Show("Автор успешно удален");
        }

        //изменение автора
        public static void EditAuthor(Author oldAuthor, string new_name, string new_surname)
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                var author = applicationContext.Authors.FirstOrDefault(a => a.Id == oldAuthor.Id);
                author.Name = new_name;
                author.Surname = new_surname;
                applicationContext.SaveChanges();

            }
        }

        //все авторы
        public static List<Author> GetAllAuthors()
        {
            using(ApplicationContext applicationContext = new ApplicationContext())
            {
                var authors = applicationContext.Authors.ToList();
                return authors;
            }
        }

        public static Author GetSurnameByID(int Id)
        {
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                var author = applicationContext.Authors.FirstOrDefault(a => a.Id == Id);
                return author;
            }
        }

        public static Author? GetAuthor { get; set; }

        public static void AddAuthorInXML(Author author)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Author));
            using (FileStream fileStream = new FileStream("Author.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fileStream, author);
            }
        }

        public static void AddAuthorInJSON(Author author)
        {
            using (FileStream fileStream = new FileStream("AuthorJson.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fileStream, author);
            }
        }

        public static void AddAuthorInText(Author author)
        {
            string[] strings = { author.Name, author.Surname };
            File.WriteAllLines("AuthorText.txt", strings);
        }
    }
}
