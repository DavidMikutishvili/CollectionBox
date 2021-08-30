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
    public class StampTagsController : ControllerBase
    {
        private readonly IStampTagRepository _repository;

        public StampTagsController(IStampTagRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllStampTags")]
        public IEnumerable<StampTag> GetAll()
        {
            return _repository.GetAllTags();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetStampTagById")]
        public StampTag CetById(int id)
        {
            return _repository.GetTagById(id);
        }

        [HttpPost]
        public IActionResult AddCollection([FromBody] StampTag tag)
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
        public IActionResult Update([FromBody] StampTag tag)
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

        private IActionResult BadRequest(Exception innerException)
        {
            throw new NotImplementedException();
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
