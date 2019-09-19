using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);
        Owner DeleteOwner(Owner owner);
        Owner GetOwner(int id);
        List<Owner> GetAllOwners();
        Owner UpdateOwner(Owner toBeUpdated, Owner updatedOwner);
    }
}
