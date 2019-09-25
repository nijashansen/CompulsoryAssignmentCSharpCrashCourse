using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IOwnerRepository
    {
        Owner AddOwner(Owner owner);
        Owner DeleteOwner(int id);
        FilteringList<Owner> ReadOwners(Filter filter);
        Owner ReadOwner(int id);
        Owner UpdateOwner(Owner toBeUpdated);
        int Count();
    }
}
