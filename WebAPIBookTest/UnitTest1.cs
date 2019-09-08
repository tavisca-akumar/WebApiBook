using System;
using Xunit;
using WebAPIBook.Model;
using System.Collections.Generic;
using WebAPIBook.Services;
using WebAPIBook.Data;
using FluentAssertions;
namespace WebAPIBookTest
{
    public class UnitTest1
    {

        BookServices bookServices = new BookServices();
        Response response;
       [Fact]
       public void GetAllBooks()
       {
            response = bookServices.GetBooks();
            Assert.Equal(200, response.StatusCode);
       }
        [Fact]
        public void GetBookwithId()
        {
            response = bookServices.GetBookbyId(3);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void AddValidBook()
        {
            Book book = new Book
            {
                BookName = "TheLastQuestion",
                BookAuthor = "IssacAsimov",
                BookCategory = "ScienceFiction",
                BookID = 5,
                Price=1500          
            };
            response = bookServices.AddBook(book);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void DeleteBookbyValidId()
        {
            response = bookServices.DeleteBook(2);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void UpdateBookById()
        {
            Book book = new Book
            {
                BookName = "TheLastQuestion",
                BookAuthor = "IssacAsimov",
                BookCategory = "ScienceFiction",
                BookID = 5,
                Price = 1500
            };
            response = bookServices.UpdateBook(2, book);
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public void GetError404_by_Entering_Wrong_id()
        {
            response = bookServices.GetBookbyId(45);
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public void GetError406_by_Entering_Negative_id()
        {
            response = bookServices.GetBookbyId(-3);
            Assert.Equal(406, response.StatusCode);
        }

        [Fact]
        public void AddBook_With_Wrong_BookName()
        {
            Book book = new Book
            {
                BookName = "The Last 54 Question",
                BookAuthor = "Issac Asimov",
                BookCategory = "Science Fiction",
                BookID = 2,
                Price = 1500
            };
            response = bookServices.AddBook(book);
            Assert.Equal(406, response.StatusCode);
        }

        [Fact]
        public void AddBook_With_Wrong_Id()
        {
            Book book = new Book
            {
                BookName = "The Last Question",
                BookAuthor = "Issac Asimov",
                BookCategory = "Science Fiction",
                BookID = -45,
                Price = 1500
            };
            response = bookServices.AddBook(book);
            Assert.Equal(406, response.StatusCode);
        }

        [Fact]
        public void DeleteBook_With_Wrong_Id_Error404()
        {
            response = bookServices.DeleteBook(45);
            Assert.Equal(404, response.StatusCode);
        }

        [Fact]
        public void DeleteBook_With_Negative_id_Error406()
        {
            response = bookServices.DeleteBook(-121);
            Assert.Equal(406, response.StatusCode);
        }

       
    }

   
}
