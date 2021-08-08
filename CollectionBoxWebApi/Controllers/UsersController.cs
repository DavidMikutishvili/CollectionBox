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
    [Produces("application/json")]
    [Route("api/Todo")]
    public class UsersController : ControllerBase
    {
        GenericRepository<Collection> _repository = new GenericRepository<Collection>(); // null is needed ?
        
        //public UsersController()
        //{
        //    _repository = new GenericRepository<User>();
        //
        //public UsersController(IGenericRepository<User> repository)
        //{
        //    _repository = repository;
        //}

        [Route("~/api/GetAllTodos")]
        [HttpGet]
        public IEnumerable<Collection> GetAll()
        {
            return _repository.GetAll();
        }

        [Route("~/api/AddTodo")]
        [HttpPost]
        public void AddUser<T>([FromBody] Collection collection)
        {
            _repository.Create(collection);
            //_repository.Save();
        }
    }
}
