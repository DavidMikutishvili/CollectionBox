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
    public class AlcoholTagsController
    {
        private IAlcoholTagRepository _repository;

        public AlcoholTagsController(IAlcoholTagRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllAlcoholTags")]
        public IEnumerable<AlcoholTag> GetAll()
        {
            return _repository.GetAllTags();
        }

        [HttpGet("{id}", Name = "GetAlcoholTagById")]
        public AlcoholTag CetById(int id)
        {
            return _repository.GetTagById(id);
        }

        [HttpPost]
        public void AddCollection([FromBody] AlcoholTag tag)
        {
            _repository.CreateTag(tag);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] AlcoholTag tag)
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
