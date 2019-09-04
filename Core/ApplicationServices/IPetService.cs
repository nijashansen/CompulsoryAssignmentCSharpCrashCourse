using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IPetService
    {
        Pet NewPet(string name, Owner prevOwner, string Color, string type, string birthday, string price, string soldDate);


        Pet CreatePet(Pet pet);

        Pet UpdatePet(Pet petUpdate);

        Pet FindPetById(int id);

        List<Pet> GetPets();

        List<Pet> GetPetsByType(string type);

        List<Pet> Get5CheapestPets();

        List<Pet> GetPetsOrderedByPrice();

        Pet Delete(int id);
        
    }
}
