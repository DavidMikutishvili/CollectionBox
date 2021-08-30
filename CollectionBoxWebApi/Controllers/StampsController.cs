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
    public class StampsController : ControllerBase
    {
        private readonly IStampRepository _repository;

        public StampsController(IStampRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllStamps")]
        public IEnumerable<Stamp> GetAll()
        {
            return _repository.GetAllStamps();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetStampById")]
        public Stamp CetById(int id)
        {
            return _repository.GetStampById(id);
        }

        [HttpPost]
        public IActionResult AddCollection([FromBody] Stamp stamp)
        {
            try
            {
                _repository.CreateStamp(stamp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Stamp stamp)
        {
            try
            {
                _repository.UpdateStamp(stamp);
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
                _repository.DeleteStamp(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }
    }
}
