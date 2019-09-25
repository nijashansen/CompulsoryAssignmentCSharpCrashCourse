using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IPetService
    {
        
        Pet CreatePet(Pet pet);
        Pet DeletePet(int id);
        Pet UpdatePet(Pet petToUpdate);
        List<Pet> GetPets();
        Pet GetPet(int id);
        List<Pet> GetFilteredPets(Filter filter);
        
    }
}
