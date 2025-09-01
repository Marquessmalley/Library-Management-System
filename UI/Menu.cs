using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.UI
{
    public static class Menu
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("Please select an option:\n1. Add Book\n2. Lists Books\n3. Register User\n4. List Users\n5. Lend user a book\n6. Return User Book\n7. Exit System");
        }

        public static void DisplayExistingSystem()
        {
            Console.WriteLine("Exiting the system. Goodbye!");
            System.Environment.Exit(0);
        }

        public static void HandleAddBook(Library library)
        {
            Console.WriteLine("\nYou choose to add a new book!");
            Console.Write("\nEnter Book Title: ");
            string? bookTitle = Console.ReadLine();
            Console.Write("\nEnter Book Author: ");
            string? bookAuthor = Console.ReadLine();
            Console.Write("\nEnter Book ISBN: ");
            int bookISBN = int.Parse(Console.ReadLine() ?? "0");

            if (bookTitle is null || bookAuthor is null)
            {
                Console.WriteLine("Book title and author cannot be null. Please try again.");
                return;
            }

            Book newBook = new(bookTitle, bookAuthor, bookISBN, false);

            library.AddBook(newBook);

            Console.WriteLine("\nBook added successfully!\n");
        }

        public static void RegisterUser(Library library)
        {
            Console.WriteLine("You choose to register a new user!");
            // Implementation for registering a user goes here

            Console.Write("\n Enter User Name: ");
            string? userName = Console.ReadLine();

            Random random = new();

            int userId = random.Next(0, 10000);

            // Check if id already exists
            for (int i = 0; i < library.Users.Count; i++)
            {
                if (library.Users[i].UserId == userId)
                {
                    userId = random.Next(0, 10000);
                }
            }

            if (userName is null)
            {
                Console.WriteLine("User name cannot be null. Please try again.");
                return;
            }

            User newUser = new(userName, userId, []);
            library.AddUser(newUser);
            Console.WriteLine($"\nUser registered successfully! User ID: {userId}\n");
        }
        public static bool UsersExists(Library library)
        {
            if (library.Users.Count == 0)
            {
                Console.WriteLine("No users are registered in the system. Please register a user first.\n");
                return false;
            }

            return true;
        }

        public static bool BooksExists(Library library)
        {
            if (library.Books.Count == 0)
            {
                Console.WriteLine("No books are registered in the system. Please register a book first.\n");
                return false;
            }

            return true;
        }
    }
}