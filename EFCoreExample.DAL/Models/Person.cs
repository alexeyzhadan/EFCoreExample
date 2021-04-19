using EFCoreExample.DAL.Models.Interfaces;
using System;

namespace EFCoreExample.DAL.Models
{
    public class Person : IEntity
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}