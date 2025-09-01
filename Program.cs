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
                        Menu.UsersExists(library);
                        library.ListUsers();
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Lending user a book...\n");
                        // Checking if there are atleast one user & book in the system.
                        bool usersExists = Menu.UsersExists(library);
                        bool booksExists = Menu.BooksExists(library);

                        if (!usersExists || !booksExists)
                        {
                            Menu.DisplayMainMenu();
                            selectedOption = Console.ReadLine();
                            break;
                        }

                        // Only lending the first book to the first user for simplicity.
                        library.LendUserBook(library.Users[0], library.Books[0]);
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;

                    case "6":
                        Console.WriteLine("Returning user a book...\n");
                        // Checking if there are atleast one user & book in the system.
                        usersExists = Menu.UsersExists(library);
                        booksExists = Menu.BooksExists(library);

                        if (!usersExists || !booksExists)
                        {
                            Menu.DisplayMainMenu();
                            selectedOption = Console.ReadLine();
                            break;
                        }

                        library.ReturnUserBook(library.Users[0], library.Books[0]);
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    case "7":
                        Menu.DisplayExistingSystem();
                        break;
                    default:
                        Console.WriteLine("Invalid option selected. Please try again.");
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();

                        break;
                }
            } while (selectedOption != "7");


            Menu.DisplayExistingSystem();

        }

    }

}