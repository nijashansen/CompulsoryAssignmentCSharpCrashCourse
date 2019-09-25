using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IOwnerRepository
    {
        Owner AddOwner(Owner owner);
        Owner DeleteOwner(Owner owner);
        IEnumerable<Owner> ReadOwners(Filter filter = null);
        Owner ReadOwner(int id);
        Owner UpdateOwner(Owner toBeUpdated, Owner updatedOwner);
        int Count();
    }
}
