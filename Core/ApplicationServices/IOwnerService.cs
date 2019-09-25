using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IOwnerService
    {
        Owner CreateOwner(Owner owner);
        Owner DeleteOwner(int id);
        Owner GetOwner(int id);
        FilteringList<Owner> GetOwners(Filter filter);
        Owner UpdateOwner(Owner toBeUpdated);
        
    }
}
