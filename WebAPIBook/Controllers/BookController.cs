using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIBook.Services;
using WebAPIBook.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIBook.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        BookServices bookService = new BookServices();
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return bookService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<Book> Post([FromBody]Book book)
        {
            bookService.Post(book);
            return bookService.Get();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IEnumerable<Book> Delete(int id)
        {
            bookService.Delete(id);
            return bookService.Get();
        }
    }
}
