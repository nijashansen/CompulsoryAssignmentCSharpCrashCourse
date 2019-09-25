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
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        public Pet DeletePet(Pet pet)
        {
            //Pet petRemoved = _context.Remove(new Pet { id = pet.id}).Entity;
            _context.Remove(pet);
            _context.SaveChanges();
            return pet;
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

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            if (filter == null)
            {
                return _context.Pets.Include(p => p.ownersHistory)
                    .ThenInclude(po => po.Pet).ToList();
            }

            return _context.Pets.Include(p => p.ownersHistory)
                .ThenInclude(po => po.Pet)
                .Skip((filter.CurrentPage - 1) * filter.InfoPrPage)
                .Take(filter.InfoPrPage).ToList();
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            _context.Attach(petToUpdate).State = EntityState.Modified;
            _context.Entry(petToUpdate).Reference(p => p.ownersHistory).IsModified = true;
            _context.SaveChanges();

            updatedPet = petToUpdate;
            return updatedPet;
        }

    } 
}
