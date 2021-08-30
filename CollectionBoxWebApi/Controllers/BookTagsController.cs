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
    public class BookTagsController : ControllerBase
    {
        private readonly IBookTagRepository _repository;

        public BookTagsController(IBookTagRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllBookTags")]
        public IEnumerable<BookTag> GetAll()
        {
            return _repository.GetAllTags();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetBookTagById")]
        public BookTag CetById(int id)
        {
            return _repository.GetTagById(id);
        }

        [HttpPost]
        public void AddCollection([FromBody] BookTag tag)
        {
            _repository.CreateTag(tag);
        }

        [HttpPut]
        public IActionResult Update([FromBody] BookTag tag)
        {
            try
            {
                _repository.UpdateTag(tag);
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
                _repository.DeleteTag(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }
    }
}
