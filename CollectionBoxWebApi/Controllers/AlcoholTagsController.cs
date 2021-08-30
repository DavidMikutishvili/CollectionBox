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
    public class AlcoholTagsController : ControllerBase
    {
        private readonly IAlcoholTagRepository _repository;

        public AlcoholTagsController(IAlcoholTagRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllAlcoholTags")]
        public IEnumerable<AlcoholTag> GetAll()
        {
            return _repository.GetAllTags();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetAlcoholTagById")]
        public AlcoholTag CetById(int id)
        {
            return _repository.GetTagById(id);
        }

        [HttpPost]
        public IActionResult AddCollection([FromBody] AlcoholTag tag)
        {
            try
            {
                _repository.CreateTag(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] AlcoholTag tag)
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
