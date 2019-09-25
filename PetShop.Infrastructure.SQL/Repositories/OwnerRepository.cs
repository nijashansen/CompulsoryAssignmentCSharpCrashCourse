using Core.DomainServices;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private PetShopContext _context;

        public OwnerRepository(PetShopContext context)
        {
            _context = context;
        }
        public Owner AddOwner(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var entityRemoved = _context.Remove(new Owner { id = id }).Entity;
            _context.SaveChanges();
            return entityRemoved;

            //Øverste sender kun 1 request til DB, mens den neden under sender 2.

            /*var removing = _context.pets.FirstOrDefault(p => p.ID == pet.ID);
            _context.Remove(removing);
            _context.SaveChanges();
            return removing;*/
        }

        public Owner ReadOwner(int id)
        {
            return _context.Owners
                .Include(o => o.petHistory)
                .ThenInclude(po => po.Pet)
                .FirstOrDefault(o => o.id == id);
        }

        public FilteringList<Owner> ReadOwners(Filter filter)
        {
            var filteredList = new FilteringList<Owner>();

            if (filter != null && filter.CurrentPage > 0 && filter.InfoPrPage > 0)
            {
                filteredList.List = _context.Owners
                    .Skip((filter.CurrentPage - 1) * filter.InfoPrPage)
                    .Take(filter.InfoPrPage)
                    .OrderBy(o => o.id)
                    .Include(p => p.petHistory)
                    .ThenInclude(po => po.Pet)
                    .ToList();
                return filteredList;
            }
            filteredList.List = _context.Owners
                .Include(p => p.petHistory)
                .ThenInclude(po => po.Pet);
            filteredList.Count = filteredList.List.Count();
            return filteredList;
        }

        public Owner UpdateOwner(Owner toBeUpdated)
        {
            if (toBeUpdated != null)
            {
                _context.Attach(toBeUpdated).State = EntityState.Modified;
                //_context.Entry(petUpdate).Collection(p => p.ownersHistory).IsModified = true;
            }
            var petOwners = new List<PetOwner>(toBeUpdated.petHistory ?? new List<PetOwner>());
            _context.PetOwners.RemoveRange(
                _context.PetOwners.Where(p => p.PetId == toBeUpdated.id)
            );
            foreach (var po in petOwners)
            {
                _context.Entry(po).State = EntityState.Added;
            }
            _context.SaveChanges();
            return toBeUpdated;
        }

        public int Count()
        {
            return _context.Owners.Count();
        }
    }
}
