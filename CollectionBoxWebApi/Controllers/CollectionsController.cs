using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CollectionsController : ControllerBase
    {
        private ICollectionRepository _repository;

        public CollectionsController(ICollectionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllCollections")]
        public IEnumerable<CollectionGallery> GetAll()
        {
            return _repository.GetAllCollections();
        }

        [HttpGet("{id}", Name = "GetCollectionById")]
        public CollectionGallery CetById(int id)
        {
            return _repository.GetCollectionById(id);
        }

        [HttpPost]
        public void AddCollection([FromBody] CollectionGallery collectionGallery)
        {
            _repository.CreateCollection(collectionGallery);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] CollectionGallery collectionGallery)
        {
            //if (user == null || user.Id != id)
            //{
            //    return BadRequest();
            //}
            _repository.UpdateCollection(collectionGallery);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.DeleteCollection(id);
        }
    }
}
