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
        [Fact]
        public void Testing_Count_of_books()
        {

            var BookList = bookServices.Get();
            Assert.Equal(4, BookList.Count);
        }

        [Fact]
        public void GetBookByCorrectIdTest()
        {
            int id = 1;
            var book = bookServices.Get(id);
            Assert.Equal(id, book.BookID);
        }

        [Fact]
        public void Test2()
        {
            List<Book> actual = bookServices.Get();

            List<Book> expected = new List<Book>
            {
                new Book { BookID = 1, BookName = "HarryPotter", BookAuthor = "Rowling", BookCategory = "Fiction", Price = 1500 },
                new Book { BookID = 2, BookName = "Lord of the Rings", BookAuthor = "tokiens", BookCategory = "Fiction", Price = 400 },
                new Book { BookID = 3, BookName = "Head First Design Pattern", BookAuthor = "Kathy Siera", BookCategory = "Computer", Price = 900 },
                new Book { BookID = 4, BookName = "My Experiments with truth", BookAuthor = "M.K Gandhi", BookCategory = "AutoBiography", Price = 200 }
            };

        }
        


        [Fact]
        public void GetBookByWrongIdTest()
        {
            int id = 11341;
            Assert.Throws<BookNotFoundException>(() => bookServices.Get(id));
        }
    }

   
}
