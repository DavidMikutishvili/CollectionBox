using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.Repositories;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllBooks")]
        public IEnumerable<Book> GetAll()
        {
            return _repository.GetAllBooks();
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public Book CetById(int id)
        {
            return _repository.GetBookById(id);
        }

        [HttpPost]
        public void AddCollection([FromBody] Book book)
        {
            _repository.CreateBook(book);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Book book)
        {
            //if (user == null || user.Id != id)
            //{
            //    return BadRequest();
            //}
            _repository.UpdateBook(book);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteBook(id);
        }
    }
}
