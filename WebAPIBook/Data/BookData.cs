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
        private List<Book> _bookList = new List<Book>();

        public BookData()
        {
            _bookList.Add(new Book { BookID = 1, BookName = "HarryPotter", BookAuthor = "Rowling", BookCategory = "Fiction", Price = 1500 });
            _bookList.Add(new Book { BookID = 2, BookName = "Lord of the Rings", BookAuthor = "tokiens", BookCategory = "Fiction", Price = 400 });
            _bookList.Add(new Book { BookID = 3, BookName = "Head First Design Pattern", BookAuthor = "Kathy Siera", BookCategory = "Computer", Price = 900 });
            _bookList.Add(new Book { BookID = 4, BookName = "My Experiments with truth", BookAuthor = "M.K Gandhi", BookCategory = "AutoBiography", Price = 200 });

        }

        public List<Book> GetBooks()
        {
            return _bookList;
        }

        public Book GetBook(int id)
        {
           foreach(Book book in _bookList)
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
            _bookList.Add(book);
        }

        public void DeleteBook(int id)
        {
            foreach(var book in _bookList)
            {
                if (book.BookID == id)
                {
                    _bookList.Remove(book);
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
