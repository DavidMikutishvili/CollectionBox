using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookTagsController : ControllerBase
    {
        private IBookTagRepository _repository;

        public BookTagsController(IBookTagRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllBookTags")]
        public IEnumerable<BookTag> GetAll()
        {
            return _repository.GetAllTags();
        }

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

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] BookTag tag)
        {
            //if (user == null || user.Id != id)
            //{
            //    return BadRequest();
            //}
            _repository.UpdateTag(tag);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteTag(id);
        }
    }
}
