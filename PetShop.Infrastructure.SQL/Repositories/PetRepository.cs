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
            var petToCreate = _context.pets.Add(pet).Entity;
            _context.SaveChanges();
            return petToCreate;
        }
        
        public Pet ReadPetById(int id)
        {
            return _context.pets.Include(pet => pet.PrevOwner).FirstOrDefault(prop => prop.Id == id);
        }

        public Pet ReadPetByIdIncludingOwner(int id)
        {
            return _context.pets
                .Where(p => p.Id == id)
                .Include(p => p.PrevOwner)
                .FirstOrDefault();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _context.pets.Include(p => p.PrevOwner).ToList();
        }

        public Pet UpdatePet(Pet petToBeUpdated)
        {
            throw new NotImplementedException();
        }
        
        public Pet Delete(int petToDelete)
        {
            var petRemove = _context.Remove<Pet>(new Pet() {Id = petToDelete}).Entity;
            _context.SaveChanges();
            return petRemove;
        }

        
    }
}
