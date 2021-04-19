using EFCoreExample.DAL.Models;
using System.Linq;

namespace EFCoreExample.DAL.Repositories.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        IQueryable<Person> GetByFirstName(string firstName);
    }
}