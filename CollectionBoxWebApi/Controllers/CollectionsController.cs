using CollectionBoxWebApi.DataLayer.Entities;
using CollectionBoxWebApi.DataLayer.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CollectionBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin, User")]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionRepository _repository;

        public CollectionsController(ICollectionRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllCollections")]
        public IEnumerable<CollectionGallery> GetAll()
        {
            return _repository.GetAllCollections();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetCollectionById")]
        public CollectionGallery CetById(int id)
        {
            return _repository.GetCollectionById(id);
        }

        [HttpPost]
        public IActionResult AddCollection([FromBody] CollectionGallery collectionGallery)
        {
            try
            {
                _repository.CreateCollection(collectionGallery); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] CollectionGallery collectionGallery)
        { 
            try
            {
                _repository.UpdateCollection(collectionGallery);
            }
            catch(Exception ex) 
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
                _repository.DeleteCollection(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }
    }
}
