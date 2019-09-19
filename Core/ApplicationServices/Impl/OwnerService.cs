using System;
using System.Collections.Generic;
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
        
        public Owner DeleteOwner(Owner owner) 
        { 
            return _ownerRepo.DeleteOwner(owner);
        }
        
        public List<Owner> GetAllOwners() 
        {
            return _ownerRepo.ReadOwners().ToList(); 
        }

        public Owner GetOwner(int id) 
        { 
            return _ownerRepo.ReadOwner(id);
        }

        public Owner UpdateOwner(Owner toBeUpdated, Owner updatedOwner) 
        { 
            return _ownerRepo.UpdateOwner(toBeUpdated, updatedOwner);
        }
    }
}
