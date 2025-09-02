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

                    // Adding Book
                    case "1":
                        Menu.HandleAddBook(library);
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;

                    // Listing Books
                    case "2":
                        Console.WriteLine("Listing Books...\n");
                        library.ListBooks();
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    // Registering User
                    case "3":
                        Menu.RegisterUser(library);
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    // Listing Users
                    case "4":
                        Console.WriteLine("Listing Users...\n");
                        Menu.UsersExists(library);
                        library.ListUsers();
                        Menu.DisplayMainMenu();
                        selectedOption = Console.ReadLine();
                        break;
                    // Lending User a Book
                    case "5":
                        {
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

                            // Get user name
                            Console.Write("\nEnter user name to checkout book: ");
                            string? enteredUserName = Console.ReadLine();
                            User? foundUser;

                            // Check if user exists in the system
                            if (enteredUserName is not null)
                            {
                                foundUser = Menu.FindUser(library, enteredUserName);

                                if (foundUser is null)
                                {
                                    Console.WriteLine("User does not exists in system.\n");
                                    Menu.DisplayMainMenu();
                                    selectedOption = Console.ReadLine();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n You enetered a invalid user name.");
                                Menu.DisplayMainMenu();
                                selectedOption = Console.ReadLine();
                                break;
                            }

                            // Get book title
                            Console.Write("\nEnter the book you want to checkout: ");
                            string? enteredBook = Console.ReadLine();
                            Book? foundBook;
                            // Check if book exists in the system
                            if (enteredBook is not null)
                            {
                                foundBook = Menu.FindBook(library, enteredBook);
                                if (foundBook is null)
                                {
                                    Console.WriteLine("Book does not exists in system.\n");
                                    Menu.DisplayMainMenu();
                                    selectedOption = Console.ReadLine();
                                    break;
                                }
                            }

                            else
                            {
                                Console.WriteLine("\n You entered a invalid book.");
                                Menu.DisplayMainMenu();
                                selectedOption = Console.ReadLine();
                                break;
                            }


                            // Check if book is already borrowed

                            if (foundBook.IsBorrowed)
                            {
                                Console.WriteLine("Book is already checked out");
                                Menu.DisplayMainMenu();
                                selectedOption = Console.ReadLine();
                                break;
                            }
                            else
                            {
                                // Lend book to user
                                library.LendUserBook(foundUser, foundBook);
                            }

                            Menu.DisplayMainMenu();
                            selectedOption = Console.ReadLine();
                            break;
                        }
                    // Returning User a Book
                    case "6":
                        {
                            Console.WriteLine("Returning user a book...\n");

                            bool usersExists = Menu.UsersExists(library);
                            bool booksExists = Menu.BooksExists(library);

                            if (!usersExists || !booksExists)
                            {
                                Menu.DisplayMainMenu();
                                selectedOption = Console.ReadLine();
                                break;
                            }

                            // Get user name
                            Console.Write("\nEnter user name to return book: ");
                            string? enteredUserName = Console.ReadLine();
                            User? foundUser;

                            // Check if user exists in the system
                            if (enteredUserName is not null)
                            {
                                foundUser = Menu.FindUser(library, enteredUserName);

                                if (foundUser is null)
                                {
                                    Console.WriteLine("User does not exists in system.\n");
                                    Menu.DisplayMainMenu();
                                    selectedOption = Console.ReadLine();
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n You enetered a invalid user name.");
                                Menu.DisplayMainMenu();
                                selectedOption = Console.ReadLine();
                                break;
                            }

                            // Get book title
                            Console.Write("\nEnter the book you want to return: ");
                            string? enteredBook = Console.ReadLine();
                            Book? foundBook;
                            // Check if book exists in the system
                            if (enteredBook is not null)
                            {
                                foundBook = Menu.FindBook(library, enteredBook);
                                if (foundBook is null)
                                {
                                    Console.WriteLine("Book does not exists in system.\n");
                                    Menu.DisplayMainMenu();
                                    selectedOption = Console.ReadLine();
                                    break;
                                }
                            }

                            else
                            {
                                Console.WriteLine("\n You entered a invalid book.");
                                Menu.DisplayMainMenu();
                                selectedOption = Console.ReadLine();
                                break;
                            }


                            // Check if book is already borrowed

                            if (foundBook.IsBorrowed)
                            {
                                library.ReturnUserBook(foundUser, foundBook);
                            }
                            else
                            {
                                Console.WriteLine("Book is already checked out");
                                Menu.DisplayMainMenu();
                                selectedOption = Console.ReadLine();
                                break;
                            }


                            Menu.DisplayMainMenu();
                            selectedOption = Console.ReadLine();
                            break;
                        }
                    // Exiting the system
                    case "7":
                        Menu.DisplayExistingSystem();
                        break;
                    // Invalid Option
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