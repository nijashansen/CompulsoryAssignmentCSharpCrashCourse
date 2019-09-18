using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IOwnerService
    {
        Owner NewOwner(string name);


        Owner CreateOwner(Owner owner);
        
        Owner FindOwnerById(int id);
        
        List<Owner> GetOwners();

        Owner UpdateOwner(Owner ownerUpdate);

        Owner Delete(int id);
    }
}
