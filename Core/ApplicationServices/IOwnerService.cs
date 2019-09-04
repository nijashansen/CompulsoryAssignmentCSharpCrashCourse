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

        Owner UpdateOwner(Owner ownerUpdate);

        Owner FindOwnerById(int id);

        List<Owner> GetOwners();

        Owner Delete(int id);
    }
}
