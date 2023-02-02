using AddressBook_ConsoleApp.Models;
using AddressBook_ConsoleApp.Interfaces;
using AddressBook_ConsoleApp.Services;





var menu = new Menu();




menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

while (true)
{
    Console.Clear();
    menu.WelcomeMenu();
}

