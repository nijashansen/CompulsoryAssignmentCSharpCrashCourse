using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainServices;
using Core.Entity;

namespace Core.ApplicationServices.Impl
{
    public class PetService: IPetService
    {
        readonly IPetRepository _petRepo;

        public PetService(IPetRepository petRepository)
        {
            _petRepo = petRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public Pet DeletePet(Pet pet)
        {

            return _petRepo.DeletePet(pet);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            List<Pet> fiveCheapestPets = new List<Pet>();
            IEnumerable<Pet> pets = _petRepo.ReadPets().OrderBy(pet => pet.price);
            List<Pet> petsordered = pets.ToList();
            foreach (Pet pet in petsordered)
            {
                if (fiveCheapestPets.Count == 5)
                {
                    break;
                }
                else
                {
                    fiveCheapestPets.Add(pet);
                }
            }
            return fiveCheapestPets;
        }

        public Pet GetPet(int id)
        {
            return _petRepo.readPet(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public List<Pet> GetPetsByOrderedPrice()
        {
            IEnumerable<Pet> pets = _petRepo.ReadPets().OrderBy(pet => pet.price);

            return pets.ToList();
        }

        public List<Pet> GetPetsByType(PetTypes type)
        {
            List<Pet> petsByType = new List<Pet>();
            List<Pet> pets = _petRepo.ReadPets().ToList();
            foreach (Pet pet in pets)
            {
                if (type == pet.type)
                {
                    petsByType.Add(pet);
                }
            }
            return petsByType;
        }

        public Pet UpdatePet(Pet petToUpdate, Pet updatedPet)
        {
            return _petRepo.UpdatePet(petToUpdate, updatedPet);
        }


    }
}
