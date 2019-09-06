using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WebAPIBook.Model;

namespace WebAPIBook.Data
{
    public class BookData
    {
        List<Book> BookList = new List<Book>();

        public BookData()
        {
            BookList.Add(new Book { BookID = 1, BookName = "HarryPotter", BookAuthor = "Rowling", BookCategory = "Fiction", Price = 1500 });
            BookList.Add(new Book { BookID = 2, BookName = "Lord of the Rings", BookAuthor = "tokiens", BookCategory = "Fiction", Price = 400 });
            BookList.Add(new Book { BookID = 3, BookName = "Head First Design Pattern", BookAuthor = "Kathy Siera", BookCategory = "Computer", Price = 900 });
            BookList.Add(new Book { BookID = 4, BookName = "My Experiments with truth", BookAuthor = "M.K Gandhi", BookCategory = "AutoBiography", Price = 200 });

        }

        public List<Book> GetBooks()
        {
            return BookList;
        }

        public Book GetBook(int id)
        {
           foreach(Book book in BookList)
            {
                if (book.BookID == id)
                {
                    return book;
                }
            }
            throw new BookNotFoundException();
        }

        public void AddBook(Book book)
        {
            BookList.Add(book);
        }

        public void DeleteBook(int id)
        {
            foreach(var book in BookList)
            {
                if (book.BookID == id)
                {
                    BookList.Remove(book);
                }

            }
            throw new BookNotFoundException();
           

        }


    }

    [Serializable]
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException()
        {
        }

        public BookNotFoundException(string message) : base(message)
        {
        }

        public BookNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
