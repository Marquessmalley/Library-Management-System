using LibraryManagementSystem.Models;
using LibraryManagementSystem.UI;

namespace LibrarayManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Entry point for the Library Management System application
            Library library = new();

            Console.WriteLine("Welcome to the Library Management System!");
            Console.WriteLine("========================================");
            Menu.DisplayMainMenu();

            string? selectedOption = Console.ReadLine();

            do
            {
                switch (selectedOption)
                {
                    case "1":
                        Menu.HandleAddBook(library);
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Listing Books...\n");
                        library.ListBooks();
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    case "3":
                        Menu.RegisterUser(library);
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Listing Users...\n");
                        library.ListUsers();
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    case "5":
                        Menu.DisplayExistingSystem();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;
                }
            } while (selectedOption != "5");


            Menu.DisplayExistingSystem();

        }

    }

}