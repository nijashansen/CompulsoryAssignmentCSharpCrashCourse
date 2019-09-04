using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IOwnerRepository
    {

        Owner CreateOwner(Owner owner);

        Owner ReadOwnerById(int id);

        IEnumerable<Owner> ReadOwners();

        Owner UpdateOwner(Owner ownerToBeUpdated);

        Owner Delete(int ownerToDelete);

    }
}
