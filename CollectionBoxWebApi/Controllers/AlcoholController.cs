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
    public class AlcoholController : ControllerBase
    {
        private IAlcoholRepository _repository;

        public AlcoholController(IAlcoholRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllAlcohol")]
        public IEnumerable<Alcohol> GetAll()
        {
            return _repository.GetAllAlcohol();
        }

        [HttpGet("{id}", Name = "GetAlcoholById")]
        public Alcohol CetById(int id)
        {
            return _repository.GetAlcoholById(id);
        }

        [HttpPost]
        public void AddCollection([FromBody] Alcohol alcohol)
        {
            _repository.CreateAlcohol(alcohol);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Alcohol alcohol)
        {
            //if (user == null || user.Id != id)
            //{
            //    return BadRequest();
            //}
            _repository.UpdateAlcohol(alcohol);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteAlcohol(id);
        }
    }
}
