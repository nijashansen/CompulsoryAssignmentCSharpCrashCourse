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
            "Exit"
        };

        public void StartUI()
        {
            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetPets();
                        ListPets(pets);
                        break;
                    case 2:
                        var name = AskQuestion("Name: ");
                        var prevOwner = AskQuestion("Pevious Owner: ");
                        var Color = AskQuestion("Color: ");
                        var type = AskQuestion("Type of Animal: ");
                        var birthday = AskQuestion("Birthday: ");
                        var price = AskQuestion("Price: ");
                        var soldDate = AskQuestion("Sold Date: ");

                        var pet = _petService.NewPet(name, prevOwner, Color, type, birthday, price, soldDate);
                        _petService.CreatePet(pet);

                        break;
                    case 3:
                        var idForDelete = PrintFindPetById();
                        _petService.Delete(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var NewPrevOwner = AskQuestion("Pevious Owner: ");
                        var NewColor = AskQuestion("Color: ");
                        var NewType = AskQuestion("Type of Animal: ");
                        var NewBirthday = AskQuestion("Birthday: (YYYY/MM/DD)");
                        var NewPrice = AskQuestion("Price: ");
                        var NewSoldDate = AskQuestion("Sold Date: ");

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
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("bye Pets");

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
                || selection > 5)
            {
                Console.WriteLine("you ned to select a number between 1 - 5");
            }


            return selection;
        }

        private void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine("ID: " + pet.ID +
                    ", Name: " + pet.Name +
                    ", Color: " + pet.Color +
                    ", Type: " + pet.TypeOfPet +
                    ", Price: " + pet.Price +
                    ", Previous Owner: " + pet.PrevOwner +
                    ", Birthday: " + pet.BirthDay +
                    ", Sold Date: " + pet.SoldDate);
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
