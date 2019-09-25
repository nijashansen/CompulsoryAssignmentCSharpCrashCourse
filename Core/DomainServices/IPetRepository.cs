using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets(Filter filter = null);
        Pet CreatePet(Pet pet);
        Pet DeletePet(Pet pet);
        Pet UpdatePet(Pet petToUpdate, Pet updatedPet);
        Pet readPet(int id);
        int Count();
    }
}
