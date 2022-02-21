using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Services
{
    public class Person : IPerson
    {
        private readonly PersonContext _context;

        public Person(PersonContext context)
        {
            _context = context;
        }
        public async Task<PersonModel> Create(PersonModel person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task Delete(int id)
        {
            var rs = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(rs);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(PersonModel person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<PersonModel> GetPersons(string fn, string ln, string address)
        {
            if(fn != null)
            {
                return _context.Persons.FirstOrDefault(x => x.FirstName == fn && x.LastName == ln && x.Address == address );                
            }
            if (ln != null)
            {
                return _context.Persons.FirstOrDefault(x => x.LastName == ln);
            }
            if (address != null)
            {
                return _context.Persons.FirstOrDefault(x => x.Address == address);
            }
            return null;
        }
        public async Task<PersonModel> GetPersons(string gender)
        {
            
            if (gender != null)
            {
                return _context.Persons.FirstOrDefault(x => x.Gender == gender);
            }
            return null;
        }

        public async Task<IEnumerable<PersonModel>> GetPersons()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<PersonModel> GetPersons(int id)
        {
            return await _context.Persons.FindAsync(id);

        }
    }
}
