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

        Response response = new Response();

        Validation validation = new Validation();


        public Response GetBooks()
        {
            response.Data = bookData.GetBooks();
            response.Message = "Success";
            response.StatusCode = 200;
            response.ErrorList = null;
            return response;

        }

        public Response GetBookbyId(int id)
        {
            if (validation.IsPositive(id))
            {
                foreach(Book book in bookData.GetBooks())
                {
                    if (book.BookID == id)
                    {
                        response.Data = bookData.GetBook(id);
                        response.Message = "Success";
                        response.StatusCode = 200;
                        response.ErrorList = null;
                        return response;
                    }
                }
                response.Data = null;
                response.StatusCode = 404;
                response.Message = "Book Not found ";
                response.ErrorList.Add("The entered id book is not available");
                return response;
            }
            response.Data = null;
            response.Message = "Invalid id Entered";
            response.StatusCode = 406;
            response.ErrorList.Add("Id cannot be negative");
            return response;

        }

        public Response AddBook(Book book)
        {
            if (validation.IsBookValid(book))
            {
                bookData.AddBook(book);
                response.Data = bookData.GetBooks();
                response.Message = "Success";
                response.StatusCode = 200;
                response.ErrorList = null;
                return response;
            }
            response.Data = null;
            response.Message = "Invalid Data Entered";
            response.StatusCode = 406;
            response.ErrorList = validation.ErrorList;
            return response;
        }
        public Response DeleteBook(int id)
        {
            if (validation.IsPositive(id))
            {
                foreach(Book book in bookData.GetBooks())
                {
                    if (book.BookID == id)
                    {
                        bookData.DeleteBook(id);
                        response.Data = bookData.GetBooks();
                        response.Message = "Success";
                        response.StatusCode = 200;
                        response.ErrorList = null;
                        return response;
                    }
                }
                response.Data = null;
                response.Message = "Book not found";
                response.StatusCode = 404;
                response.ErrorList.Add("The entered Id book is not available");
                return response;
            }

            response.Data = null;
            response.Message = "Invalid id Entered";
            response.StatusCode = 406;
            response.ErrorList.Add("Id cannot be negative");
            return response;
        }
        public Response UpdateBook(int id, Book book)
        {
            if (validation.IsBookValid(book)&&validation.IsPositive(id))
            {
                foreach(Book currentbook in bookData.GetBooks())
                {
                    if (currentbook.BookID == id)
                    {
                        currentbook.BookName = book.BookName;
                        currentbook.BookAuthor = book.BookAuthor;
                        currentbook.BookCategory = book.BookCategory;
                        currentbook.BookID = book.BookID;
                        currentbook.Price = book.Price;

                        response.Data = bookData.GetBooks();
                        response.Message = "Success";
                        response.StatusCode = 200;
                        response.ErrorList = null;
                        return response;
                    }
                }
                response.Data = null;
                response.Message = "Book not found";
                response.StatusCode = 404;
                response.ErrorList.Add("The entered Id book is not available");
                return response;

            }
           else if (!validation.IsPositive(id)){
                response.Data = null;
                response.Message = "Invalid id Entered";
                response.StatusCode = 406;
                response.ErrorList.Add("Id cannot be negative");
                return response;
            }
            response.Data = null;
            response.Message = "Invalid data Entered";
            response.StatusCode = 406;
            response.ErrorList=validation.ErrorList;
            return response;
        }
    }


    public interface IBookServices
    {
        Response GetBooks();
        Response GetBookbyId(int id);

        Response AddBook(Book book);

        Response DeleteBook(int id);

        Response UpdateBook(int id, Book book);
    }
}
