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
    public class AlcoholController : ControllerBase
    {
        private readonly IAlcoholRepository _repository;

        public AlcoholController(IAlcoholRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllAlcohol")]
        public IEnumerable<Alcohol> GetAll()
        {
            return _repository.GetAllAlcohol();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetAlcoholById")]
        public Alcohol CetById(int id)
        {
            return _repository.GetAlcoholById(id);
        }

        [HttpPost]
        public IActionResult AddCollection([FromBody] Alcohol alcohol)
        {
            try
            {
                _repository.CreateAlcohol(alcohol);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Alcohol alcohol)
        {
            try
            {
                _repository.UpdateAlcohol(alcohol);
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
                _repository.DeleteAlcohol(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }
    }
}
