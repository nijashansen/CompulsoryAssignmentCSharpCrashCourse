using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core.DomainServices;
using Core.Entity;

namespace Core.ApplicationServices.Impl
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }
        
        public Owner CreateOwner(Owner owner)
        { 
            return _ownerRepo.AddOwner(owner);
        }
        
        public Owner DeleteOwner(int id) 
        { 
            return _ownerRepo.DeleteOwner(id);
        }

        public FilteringList<Owner> GetOwners(Filter filter)
        {
            return _ownerRepo.ReadOwners(filter);
        }

        public Owner GetOwner(int id) 
        { 
            return _ownerRepo.ReadOwner(id);
        }

        public Owner UpdateOwner(Owner toBeUpdated) 
        { 
            var owner = GetOwner(toBeUpdated.id);
            owner.firstName = toBeUpdated.firstName;
            owner.lastName = toBeUpdated.lastName;
            owner.address = toBeUpdated.address;
            owner.petHistory = toBeUpdated.petHistory;

            return _ownerRepo.UpdateOwner(owner);
        }
    }
}
