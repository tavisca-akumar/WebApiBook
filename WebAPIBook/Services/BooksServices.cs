using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIBook.Data;
using WebAPIBook.Model;

namespace WebAPIBook.Services
{
    public class BookServices : IBookServices
    {

        BookData bookData = new BookData();
        public void Delete(int id)
        {
            bookData.DeleteBook(id); 
        }

        public List<Book> Get()
        {
            return bookData.GetBooks();
        }

        public Book Get(int id)
        {           
                return bookData.GetBook(id); 
        }

        public void Post(Book book)
        {
            bookData.AddBook(book);
        }
    }


    public interface IBookServices
    {
        List<Book> Get();
        Book Get(int id);

        void Post(Book book);

        //void Put(int id, Book updatedBook);

        void Delete(int id);
    }
}
