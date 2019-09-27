using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IPetRepository
    {
        FilteringList<Pet> ReadPets(Filter filter = null);
        Pet CreatePet(Pet pet);
        Pet DeletePet(int id);
        Pet UpdatePet(Pet petToUpdate);
        Pet readPet(int id);
        int Count();
    }
}
