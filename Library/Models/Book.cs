using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public Book(String title,String author,String genre,int copies,String image) {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.NumberofCopies = copies;
            this.Image = image;
        }
        
        public int Id { get; set; }
        public String Title { get; set; }
        public String  Author { get; set; }
        public String Genre { get; set; }

        public String Image { get; set; }
        public int NumberofCopies { get; set; }
    }
}
