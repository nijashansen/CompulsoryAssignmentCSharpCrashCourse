using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IPetService
    {
        List<Pet> GetPets();
        Pet CreatePet(Pet pet);
        Pet DeletePet(Pet pet);
        Pet UpdatePet(Pet petToUpdate, Pet updatedPet);
        Pet GetPet(int id);
        List<Pet> GetPetsByType(PetTypes type);
        List<Pet> GetPetsByOrderedPrice();
        List<Pet> GetFiveCheapestPets();
        List<Pet> GetFilteredPets(Filter filter);
        
    }
}
