using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIBook.Model
{
    public class Book
    {
        

        public string BookName { get; set; }

        public string BookCategory { get; set; }

        public string BookAuthor { get; set; }

        public int Price { get; set; }

        public int BookID { get; set; }
    }
}
