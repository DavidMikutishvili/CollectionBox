using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using CollectionBoxWebApi.DataLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace CollectionBoxWebApi.Controllers
{
    // todo: [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private UserRepository _repository;

        public UsersController(UserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public User CetById(int id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public void AddUser([FromBody] User user)
        {
            _repository.Create(user);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] User user)
        {
            //if (user == null || user.Id != id)
            //{
            //    return BadRequest();
            //}
            _repository.Update(user);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
