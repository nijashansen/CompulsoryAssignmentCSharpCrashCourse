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

        public IEnumerable<Pet> ReadPets()
        {
            return _context.Pets
                .Include(o => o.ownersHistory)
                .ThenInclude(po => po.Owner)
                .ToList();
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            throw new NotImplementedException();
        }

    } 
}
