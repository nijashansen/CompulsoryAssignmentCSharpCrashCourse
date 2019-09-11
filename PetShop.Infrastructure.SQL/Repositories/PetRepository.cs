using Core.DomainServices;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Infrastructure.SQL.Repositories
{
    class PetRepository : IPetRepository
    {
        private PetContext _context;

        public PetRepository(PetContext context)
        {
            _context = context;
        }

        public Pet CreatePet(Pet pet)
        {
            var petToCreate = _context.pets.Add(pet).Entity;
            _context.SaveChanges();
            return petToCreate;
        }

        public Pet Delete(int petToDelete)
        {
            var toDelete = _context.Remove(new Pet {ID = petToDelete}).Entity;
            _context.SaveChanges();
            return toDelete;
        }

        public Pet ReadPetById(int id)
        {
            return _context.pets.FirstOrDefault(prop => prop.ID == id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _context.pets.ToList();
        }

        public Pet UpdatePet(Pet petToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
