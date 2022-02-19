using RestAPI.Models;

namespace RestAPI.Services
{
    public interface IPerson
    {
        Task<IEnumerable<PersonModel>> GetPersons();
        Task<PersonModel> GetPersons(int id);
        Task<PersonModel> GetPersons(string name, string gender);
        
        Task<PersonModel> Create(PersonModel person);
        Task Edit(PersonModel person);

        Task Delete(int id);

    }
}
