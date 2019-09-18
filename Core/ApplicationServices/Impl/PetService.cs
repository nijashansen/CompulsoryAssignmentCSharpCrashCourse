﻿using System;
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

        public Pet NewPet(string name, Owner prevOwner, string Color, string type, string birthday, string price, string soldDate)
        {
            var pet = new Pet()
            {
                Name = name,
                PrevOwner = prevOwner,
                Color = Color,
                TypeOfPet = type,
                BirthDay = DateTime.Parse(birthday),
                Price = double.Parse(price),
                SoldDate = DateTime.Parse(soldDate)
            };

            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.CreatePet(pet);
        }

        public Pet FindPetById(int id)
        {
            return _petRepo.ReadPetById(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepo.ReadPets().ToList();
        }

        public Pet GetPetIncludeOwners(int id)
        {
            var pet = _petRepo.ReadPetByIdIncludingOwner(id);
            return pet;
        }

        public List<Pet> GetPetsByType(string type)
        {
            var list = _petRepo.ReadPets();

            var sortedList = list.Where(pet => pet.TypeOfPet.Equals(type));
            return sortedList.ToList();
        }

        public List<Pet> Get5CheapestPets()
        {
            var list = GetPetsOrderedByPrice();

            var sortedList = list.OrderBy(pet => pet.Price).Take(5);
            return sortedList.ToList();
        }

        public List<Pet> GetPetsOrderedByPrice()
        {
            var list = _petRepo.ReadPets();

            var orderedList = list.OrderBy(pet => pet.Price);
            return orderedList.ToList();
        }
        
        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.Id);

            pet.Name = petUpdate.Name;
            pet.PrevOwner = petUpdate.PrevOwner;
            pet.Color = petUpdate.Color;
            pet.TypeOfPet = petUpdate.TypeOfPet;
            pet.BirthDay = petUpdate.BirthDay; 
            pet.Price = petUpdate.Price;
            pet.SoldDate = petUpdate.SoldDate;
            return pet;
        }

        public Owner getOwner(Pet pet)
        {
            var pet2 = FindPetById(pet.Id);

            return pet2.PrevOwner;
        }

        public Pet Delete(int id)
        {
            return _petRepo.Delete(id);
        }

    }
}
