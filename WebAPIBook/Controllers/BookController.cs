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
        public ActionResult Get()
        {
            var response = bookService.GetBooks();
            return StatusCode(response.StatusCode,response);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var response = bookService.GetBookbyId(id);
            return StatusCode(response.StatusCode, response);

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            var response = bookService.AddBook(book);
            return StatusCode(response.StatusCode, response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Book book)
        {
            var response = bookService.UpdateBook(id, book);
            return StatusCode(response.StatusCode, response);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var response=bookService.DeleteBook(id);
            return StatusCode(response.StatusCode,response);
        }
    }
}
