using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCollection.Models
{
    [Serializable]
    public class Book
    {
        public int Id { get; set; }
        public string Book_Name { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        [NotMapped]
        public Author BookAuthorSurname
        {
            get
            {
                return DataOperations.GetSurnameByID(AuthorId);
            }
        }
    }
}
