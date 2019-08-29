using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainServices;
using Core.Entity;

namespace Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private List<Pet> _pets = FakeDB.getPets();

        public Pet CreatePet(Pet pet)
        {
            pet.ID = FakeDB.id++;
            _pets.Add(pet);
            return pet;
        }

        public Pet Delete(int petToDelete)
        {
            var petFound = this.ReadPetById(petToDelete);
            if (petFound != null)
            {
                _pets.Remove(petFound);
            }
            return null;
        }

        public Pet ReadPetById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.ID == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _pets; 
        }

        public Pet UpdatePet(Pet petToBeUpdated)
        {
            var petFromDB = this.ReadPetById(petToBeUpdated.ID);
            if (petFromDB != null)
            {
                petFromDB.Name = petToBeUpdated.Name;
                petFromDB.PrevOwner = petToBeUpdated.PrevOwner;
                petFromDB.Color = petToBeUpdated.Color;
                petFromDB.BirthDay = petToBeUpdated.BirthDay;
                petFromDB.Price = petToBeUpdated.Price;
                petFromDB.SoldDate = petToBeUpdated.SoldDate;

                return petFromDB;
            }
            return null;
        }
    }
}
