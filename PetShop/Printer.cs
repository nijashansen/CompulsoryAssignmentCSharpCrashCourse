using Core.ApplicationServices;
using Core.DomainServices;
using Core.Entity;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    class Printer : IPrinter
    {
        private IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        string[] menuItems =
        {
            "List All Pets",
            "Add A Pet",
            "Delete A Pet",
            "Edit A Pet",
            "Show Pets Ordered By Price",
            "Search For a Type of Pet",
            "Show the 5 Cheapest Pets",
            "Exit"
        };

        public void StartUI()
        {
            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        var pets = _petService.GetPets();
                        ListPets(pets);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        var name = AskQuestion("Name: ");
                        var prevOwner = AskQuestion("Pevious Owner: ");
                        var Color = AskQuestion("Color: ");
                        var type = AskQuestion("Type of Animal: ");
                        var birthday = AskQuestion("Birthday: (YYYY/MM/DD)");
                        var price = AskQuestion("Price: ");
                        var soldDate = AskQuestion("Sold Date: (YYYY/MM/DD)");

                        var pet = _petService.NewPet(name, prevOwner, Color, type, birthday, price, soldDate);
                        _petService.CreatePet(pet);
                        Console.WriteLine("Press enter to continue...");
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        var idForDelete = PrintFindPetById();
                        _petService.Delete(idForDelete);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        var idForEdit = PrintFindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var NewPrevOwner = AskQuestion("Pevious Owner: ");
                        var NewColor = AskQuestion("Color: ");
                        var NewType = AskQuestion("Type of Animal: ");
                        var NewBirthday = AskQuestion("Birthday: (YYYY/MM/DD)");
                        var NewPrice = AskQuestion("Price: ");
                        var NewSoldDate = AskQuestion("Sold Date: (YYYY/MM/DD)");

                        _petService.UpdatePet(new Pet()
                        {
                            ID = idForEdit,
                            Name = newName,
                            PrevOwner = NewPrevOwner,
                            Color = NewColor,
                            TypeOfPet = NewType,
                            BirthDay = DateTime.Parse(NewBirthday),
                            Price = double.Parse(NewPrice),
                            SoldDate = DateTime.Parse(NewSoldDate)
                        });
                        Console.WriteLine("Press enter to continue...");
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        pets = _petService.GetPetsOrderedByPrice();
                        ListPets(pets);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        Console.Clear();
                        var typeOfPet = AskQuestion("Which Type Of Pet Are You Looking For: ");
                        pets = _petService.GetPetsByType(typeOfPet);
                        ListPets(pets);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        pets = _petService.Get5CheapestPets();
                        ListPets(pets);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Have A Nice Day :P");

            Console.ReadLine();
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select Which Menu You Want To Use: \n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 9)
            {
                Console.WriteLine("you ned to select a number between 1 - 8");
            }


            return selection;
        }

        private void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine("ID: " + pet.ID +
                    ", \nName: " + pet.Name +
                    ", \nColor: " + pet.Color +
                    ", \nType: " + pet.TypeOfPet +
                    ", \nPrice: " + pet.Price +
                    ", \nPrevious Owner: " + pet.PrevOwner +
                    ", \nBirthday: " + pet.BirthDay +
                    ", \nSold Date: " + pet.SoldDate + "\n");
            }
            Console.WriteLine("\n");
        }

        
        int PrintFindPetById()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please Insert a number!");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
