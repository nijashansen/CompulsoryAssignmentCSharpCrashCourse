using System;
using System.Collections.Generic;
using System.IO;
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

        public Pet DeletePet(int id)
        {

            return _petRepo.DeletePet(id);
        }

        public Pet GetPet(int id)
        {
            return _petRepo.readPet(id);
        }

        public FilteringList<Pet> GetPets(Filter filter)
        {
            return _petRepo.ReadPets(filter);
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            var pet = GetPet(petToUpdate.id);
            pet.name = petToUpdate.name;
            pet.type = petToUpdate.type;
            pet.birthDate = petToUpdate.birthDate;
            pet.soldDate = petToUpdate.soldDate;
            pet.color = petToUpdate.color;
            pet.price = petToUpdate.price;
            pet.ownersHistory = petToUpdate.ownersHistory;

            return _petRepo.UpdatePet(pet);
        }


    }
}
