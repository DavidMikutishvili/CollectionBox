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
    public class StampTagsController
    {
        private IStampTagRepository _repository;

        public StampTagsController(IStampTagRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllStampTags")]
        public IEnumerable<StampTag> GetAll()
        {
            return _repository.GetAllTags();
        }

        [HttpGet("{id}", Name = "GetStampTagById")]
        public StampTag CetById(int id)
        {
            return _repository.GetTagById(id);
        }

        [HttpPost]
        public void AddCollection([FromBody] StampTag tag)
        {
            _repository.CreateTag(tag);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] StampTag tag)
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
