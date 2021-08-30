using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CollectionBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllBooks")]
        public IEnumerable<Book> GetAll()
        {
            return _repository.GetAllBooks();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetBookById")]
        public Book CetById(int id)
        {
            return _repository.GetBookById(id);
        }

        [HttpPost]
        public IActionResult AddCollection([FromBody] Book book)
        {
            try
            {
                _repository.CreateBook(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Book book)
        {
            try
            {
                _repository.UpdateBook(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _repository.DeleteBook(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }
    }
}
