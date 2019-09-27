using Core.DomainServices;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private PetShopContext _context;

        public PetRepository(PetShopContext context)
        {
            _context = context;
        }
        public Pet CreatePet(Pet pet)
        {
            if(pet != null)
            {
                _context.Attach(pet).State = EntityState.Added;
                _context.Entry(pet).Collection(p => p.ownersHistory).IsModified = true;
            }
            var petSaved = _context.Pets.Add(pet).Entity;
            _context.SaveChanges();
            return petSaved;
        }

        public Pet DeletePet(int id)
        {
            var entityRemoved = _context.Remove(new Pet { id = id }).Entity;
            _context.SaveChanges();
            return entityRemoved;

            //Øverste sender kun 1 request til DB, mens den neden under sender 2.

            /*var removing = _context.pets.FirstOrDefault(p => p.ID == pet.ID);
            _context.Remove(removing);
            _context.SaveChanges();
            return removing;*/
        }

        public Pet readPet(int id)
        {
            return _context.Pets
                .Include(o => o.ownersHistory)
                .ThenInclude(po => po.Owner)
                .FirstOrDefault(p => p.id == id);
        }

        public int Count()
        {
            return _context.Pets.Count();
        }

        public FilteringList<Pet> ReadPets(Filter filter)
        {
            var filteredList = new FilteringList<Pet>();

            if (filter != null && filter.CurrentPage > 0 && filter.InfoPrPage > 0)
            {
                filteredList.List = _context.Pets
                    .Skip((filter.CurrentPage - 1) * filter.InfoPrPage)
                    .Take(filter.InfoPrPage)
                    .OrderBy(o => o.id)
                    .Include(p => p.ownersHistory)
                    .ThenInclude(po => po.Owner)
                    .ToList();
                return filteredList;
            }
            filteredList.List = _context.Pets
                .Include(p => p.ownersHistory)
                .ThenInclude(po => po.Owner);
            filteredList.Count = filteredList.List.Count();
            return filteredList;
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            if (petToUpdate != null)
            {
                _context.Attach(petToUpdate).State = EntityState.Modified;
                //_context.Entry(petUpdate).Collection(p => p.ownersHistory).IsModified = true;
            }
            var petOwners = new List<PetOwner>(petToUpdate.ownersHistory ?? new List<PetOwner>());
            _context.PetOwners.RemoveRange(
                _context.PetOwners.Where(p => p.PetId == petToUpdate.id)
            );
            foreach (var po in petOwners)
            {
                _context.Entry(po).State = EntityState.Added;
            }
            _context.SaveChanges();
            return petToUpdate;
        }

    } 
}
