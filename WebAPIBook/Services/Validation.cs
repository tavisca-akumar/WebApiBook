using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIBook.Model;

namespace WebAPIBook.Services
{
    public class Validation
    {
        bool isValid = true;
        public List<string> ErrorList = new List<string>();
        public bool IsPositive(int data)
        {
            if (data > 0)
                return true;
            else
                return false;           
        }

        public bool Is_String_Valid(string data)
        {
            bool result = data.All(Char.IsLetter);
            return result;
        }
        
        public void IsBookNameValid(string BookName)
        {
            if (!Is_String_Valid(BookName))
            {
                isValid = false;
                ErrorList.Add("BookName is Invalid");
            }
        }

        public void IsBookAuthorValid(string BookAuthor)
        {
            if (!Is_String_Valid(BookAuthor))
            {
                isValid = false;
                ErrorList.Add("BookAuthor is Invalid");
            }
        }

        public void IsBookCategory(string BookCategory)
        {
            if (!Is_String_Valid(BookCategory))
            {
                isValid = false;
                ErrorList.Add("BookCategory is Invalid");
            }
            
        }

        public void IsBookIdvalid(int id)
        {
            if (!IsPositive(id))
            {
                isValid = false;
                ErrorList.Add("Book id is Negative");
            }
        }
        public void IsBookPriceValid(int price)
        {
            if (!IsPositive(price))
            {
                isValid = false;
                ErrorList.Add("Book Price is Negative");
            }
        }
        public bool IsBookValid(Book book)
        {
            IsBookNameValid(book.BookName);
            IsBookAuthorValid(book.BookAuthor);
            IsBookCategory(book.BookCategory);
            IsBookPriceValid(book.Price);
            IsBookIdvalid(book.BookID);
            return isValid;
        }
    


}
}
