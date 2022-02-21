using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using RestAPI.Services;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPerson _persons;

        public PersonsController(IPerson persons)
        {
            _persons = persons;
        }
        [HttpGet]
        public async Task<IEnumerable<PersonModel>> GetPersons()
        {
            return await _persons.GetPersons();
        }
        [HttpGet("id")]
        public async Task<ActionResult<PersonModel>> GetPersonById(int id)
        {
            return await _persons.GetPersons(id);
        }
        [HttpGet("search")]
        public async Task<ActionResult<PersonModel>> GetByName(string fn, string ln, string address)
        {
            return await _persons.GetPersons(fn, ln, address);
        }
        [HttpGet("gender")]
        public async Task<ActionResult<PersonModel>> GetByName(string gender)
        {
            return await _persons.GetPersons(gender);
        }

        [HttpPost]
        public async Task<ActionResult<PersonModel>> PostPerson([FromBody] PersonModel person)
        {
            var newPerson = await _persons.Create(person);
            return CreatedAtAction(nameof(GetPersons),
                new
                {
                    id = newPerson.Id,
                    fn = newPerson.FirstName,
                    ln = newPerson.LastName,
                    gender = newPerson.Gender,
                    age = newPerson.Age,
                    address = newPerson.Address
                }, newPerson);

        }
        [HttpPut]
        public async Task<ActionResult> PutPerson(int id, [FromBody] PersonModel person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }
            await _persons.Edit(person);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult> DeletePerson(int id)
        {
            var rs = await _persons.GetPersons(id);
            if (rs == null)
            {
                return NotFound();
            }
            await _persons.Delete(rs.Id);
            return NoContent();
        }
    }
}
