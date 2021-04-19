using EFCoreExample.DAL.Models;
using EFCoreExample.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EFCoreExample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        protected IUnitOfWork _uow;

        public PeopleController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/people
        [HttpGet]
        public ActionResult Get()
        {
            var people = _uow.People.GetAll();
            return Ok(people);
        }

        // GET api/people/4643B57B-27F2-4415-BE9D-82CAF46380DE
        [HttpGet("{id}")]
        public ActionResult Get(Guid? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var person = _uow.People.GetById(id.Value);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // POST api/people
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            _uow.People.Add(person);

            var result = _uow.Complete();
            if (result == 1)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        // PUT api/people/4643B57B-27F2-4415-BE9D-82CAF46380DE
        [HttpPut("{id}")]
        public ActionResult Put(Guid? id, [FromBody] Person person)
        {
            if (person == null || !id.HasValue || id != person.Id)
            {
                return BadRequest();
            }

            var entityForRemoving = _uow.People.GetById(id.Value);
            if (entityForRemoving == null)
            {
                return BadRequest();
            }

            _uow.People.Remove(entityForRemoving);

            _uow.People.Add(person);

            var result = _uow.Complete();
            if (result == 0)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        // DELETE api/people/4643B57B-27F2-4415-BE9D-82CAF46380DE
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            var entityForRemoving = _uow.People.GetById(id.Value);
            if (entityForRemoving == null)
            {
                return BadRequest();
            }

            _uow.People.Remove(entityForRemoving);

            var result = _uow.Complete();
            if (result == 1)
            {
                return Ok();
            }

            return StatusCode(500);
        }
    }
}