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
            if (filter.CurrentPage < 0 || filter.InfoPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage and InfoPrPage Must Zero or More");
            }

            if ((filter.CurrentPage - 1 * filter.InfoPrPage) >= _ownerRepo.Count())
            {
                throw new InvalidDataException("Index Out Of Bounds, CurrentPage is to high");
            }
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
