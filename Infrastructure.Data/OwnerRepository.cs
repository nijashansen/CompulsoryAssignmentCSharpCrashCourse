using Core.DomainServices;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {

        static readonly List<Owner> _owners = FakeDB.getOwners();

        public Owner CreateOwner(Owner owner)
        {
            owner.id = FakeDB.ownerID++;
            _owners.Add(owner);
            return owner;
        }

        public Owner Delete(int ownerToDelete)
        {
            var ownerFound = this.ReadOwnerById(ownerToDelete);
            if (ownerFound != null)
            {
                _owners.Remove(ownerFound);
            }
            return null;
        }

        public Owner ReadOwnerById(int id)
        {
            foreach (var owner in _owners)
            {
                if (owner.id == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _owners;
        }

        public Owner UpdateOwner(Owner ownerToBeUpdated)
        {
            var ownerFromDB = this.ReadOwnerById(ownerToBeUpdated.id);
            if (ownerFromDB != null)
            {
                ownerFromDB.name = ownerToBeUpdated.name;

                return ownerFromDB;
            }
            return null;
        }
    }
}
