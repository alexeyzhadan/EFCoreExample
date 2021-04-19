using EFCoreExample.DAL.Models;
using EFCoreExample.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreExample.DAL.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) 
            : base(context)
        {
        }

        protected AppDbContext Context
        {
            get
            {
                return _context as AppDbContext;
            }
        }

        public IQueryable<Person> GetByFirstName(string firstName)
        {
            return Context.People.Where(p => p.FirstName == firstName);
        }
    }
}