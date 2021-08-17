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
    public class StampsController : ControllerBase
    {
        private IStampRepository _repository;

        public StampsController(IStampRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllStamps")]
        public IEnumerable<Stamp> GetAll()
        {
            return _repository.GetAllStamps();
        }

        [HttpGet("{id}", Name = "GetStampById")]
        public Stamp CetById(int id)
        {
            return _repository.GetStampById(id);
        }

        [HttpPost]
        public void AddCollection([FromBody] Stamp stamp)
        {
            _repository.CreateStamp(stamp);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Stamp stamp)
        {
            //if (user == null || user.Id != id)
            //{
            //    return BadRequest();
            //}
            _repository.UpdateStamp(stamp);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteStamp(id);
        }
    }
}
