using Core.DomainServices;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private PetShopContext _context;

        public OwnerRepository(PetShopContext context)
        {
            _context = context;
        }

        public Owner CreateOwner(Owner owner)
        {
            var ownerToCreate = _context.owners.Add(owner).Entity;
            _context.SaveChanges();
            return ownerToCreate;
        }

        public Owner Delete(int ownerToDelete)
        {
            var toDelete = _context.Remove(new Owner { id = ownerToDelete }).Entity;
            _context.SaveChanges();
            return toDelete;
        }

        public Owner ReadOwnerById(int id)
        {
            return _context.owners.FirstOrDefault(prop => prop.id == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _context.owners.ToList();
        }

        public Owner UpdateOwner(Owner ownerToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
