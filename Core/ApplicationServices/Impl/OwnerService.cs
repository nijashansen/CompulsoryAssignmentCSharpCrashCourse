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

        public Owner NewOwner(string name)
        {
            var owner = new Owner()
            {
                name = name,
            };

            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepo.CreateOwner(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadOwnerById(id);
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepo.ReadOwners().ToList();
        }


        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var owner = FindOwnerById(ownerUpdate.id);

            owner.name = ownerUpdate.name;
            return owner;
        }


        public Owner Delete(int id)
        {
            var foundOwner = FindOwnerById(id);
            _ownerRepo.Delete(foundOwner.id);
            return foundOwner;
        }
    }
}
