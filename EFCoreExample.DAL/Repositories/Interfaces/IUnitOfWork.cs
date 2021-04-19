using System;

namespace EFCoreExample.DAL.Repositories.Interfaces
{
    // All repository interfaces and the SaveChanges method
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository People { get; }

        int Complete();
    }
}