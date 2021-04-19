using EFCoreExample.DAL.Repositories.Interfaces;

namespace EFCoreExample.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            People = new PersonRepository(context);
        }

        public IPersonRepository People { get; }

        public int Complete()
        {
            if (_context != null)
            {
                return _context.SaveChanges();    
            }

            return 0;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}