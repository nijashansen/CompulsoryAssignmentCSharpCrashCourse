using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        Pet ReadPetById(int id);
        
        Pet ReadPetByIdIncludingOwner(int id);

        IEnumerable<Pet> ReadPets();

        Pet UpdatePet(Pet petToBeUpdated);

        Pet Delete(int petToDelete);
    }
}
