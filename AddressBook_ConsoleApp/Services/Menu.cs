using AddressBook_ConsoleApp.Interfaces;
using AddressBook_ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ConsoleApp.Services;

internal class Menu
{

    public List<IContactPerson> contacts = new List<IContactPerson>();
    //private List<ContactPerson> contacts = new List<ContactPerson>();
    private FileService file = new FileService();


    public string FilePath { get; set; } = null!;
   

    public void WelcomeMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the AddressBook");
        Console.WriteLine("1. Create a contact");
        Console.WriteLine("2. Show all contacts");
        Console.WriteLine("3. Show a specific contact");
        Console.WriteLine("4. Delete a specific contact");
        Console.WriteLine("Choose one of the options above::");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1": FirstOption(); break;
            case "2": SecondOption(); break;
            case "3": ThirdOption(); break;
            case "4": FourthOption(); break;
        }
    }

    public void FirstOption()
    {
        Console.Clear();
        Console.WriteLine("Create a contact");


        IContactPerson contactPerson = new ContactPerson();
        Console.Write("Ange Förnamn: ");
        contactPerson.FirstName = Console.ReadLine() ?? "";
        Console.Write("Ange Efternamn: ");
        contactPerson.LastName = Console.ReadLine() ?? "";
        Console.Write("Ange Adress: ");
        contactPerson.Address = Console.ReadLine() ?? "";
        Console.Write("Ange Telefonnummer: ");
        contactPerson.Phone = Console.ReadLine() ?? "";
        Console.Write("Ange E-postadress: ");
        contactPerson.Email = Console.ReadLine() ?? "";

        contacts.Add(contactPerson);

        file.Save(FilePath, JsonConvert.SerializeObject(contacts));

 


    }

  
    private void SecondOption()
    {


    contacts = JsonConvert.DeserializeObject<List<IContactPerson>>(file.Read(FilePath))!;

       
        Console.Clear();
        //file.Read(FilePath);
        Console.WriteLine("Show all contacts : ");
        foreach (var contact in contacts)
            Console.WriteLine($"{contact.FirstName} {contact.LastName}  <{contact.Email}>");

        Console.WriteLine("press any key to return to the main menu");
        Console.ReadLine();


    }

    private void ThirdOption()
    {
        
       
        Console.Clear();
       // file.Read(FilePath);

        Console.WriteLine("Enter the first name of the contact whose information you want to see : ");
        string? UserInputForName = Console.ReadLine();
        var contactperson = contacts?.FirstOrDefault(x => x.FirstName == UserInputForName);
        if (contactperson != null)
        {
            Console.WriteLine($"FirstName: {contactperson.FirstName} \nLastName: {contactperson.LastName} \nEmail: {contactperson.Email} \nPhone: {contactperson.Phone} \nAddress: {contactperson.Address}");
        }

        Console.WriteLine("press any key to return to the main menu.");
        Console.ReadLine();

    }



        private void FourthOption()
    {
        Console.Clear();

        Console.WriteLine("Enter the first name of the contact to remove it : ");
            string? UserInputForName = Console.ReadLine();
            Console.WriteLine("Are you sure you want to delete this contact ? if Your answer is yes then enter : y ");
            string? answer = Console.ReadLine();

            if (answer == "y")
            {
                var contactperson = contacts?.FirstOrDefault(x => x.FirstName == UserInputForName);
                if (contactperson != null)
                {
                    contacts?.Remove(contactperson);
                    Console.WriteLine($"{contactperson.FirstName} is removed from the list");
                 file.Save(FilePath, JsonConvert.SerializeObject(contacts));
            }
            Console.WriteLine("press any key to return to the main menu ");
                Console.ReadLine();

            }

            else
            {
                Console.WriteLine("press any key to return to the main menu");
                Console.ReadLine();
            }

        }


        /*    public IContactPerson GetPersonFromList()

            {

                string? UserInputForName = Console.ReadLine(IContactPerson?.contactperson);
                var _contactperson = contacts?.FirstOrDefault(x => x.FirstName == UserInputForName);

                return _contactperson!;
            }*/

    }

