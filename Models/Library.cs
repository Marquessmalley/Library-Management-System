using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Models
{
    public class Library
    {
        public List<Book> Books { get; } = [];
        public List<User> Users { get; } = [];
        public Dictionary<User, List<Book>> UserBooks { get; } = [];

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void ListBooks()
        {

            if (Books.Count == 0)
            {
                Console.WriteLine("No books available in the library.\n");
                return;
            }

            Console.WriteLine("{0,-20} {1,-15} {2, -15} {3, -12}", "Title", "Author", "ISBN", "Checked Out\n");
            foreach (var book in Books)
            {
                Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-12}", book.Title, book.Author, book.ISBN, book.IsBorrowed, "\n");
            }
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void ListUsers()
        {
            // Check if a user exits 
            if (Users.Count == 0)
            {
                Console.WriteLine("No users are registered in the system.\n");
                return;
            }



            Console.WriteLine("{0,-20} {1,-15} {2, -15}", "Name", "User ID", "Borrowed Books\n");
            foreach (var user in Users)
            {
                string displayTitles;
                IEnumerable<string> borrowedBookTitles;
                if (user.BorrowedBooks.Count == 0)
                {
                    displayTitles = "None";
                }
                else
                {
                    borrowedBookTitles = user.BorrowedBooks.Select(b => b.Title);
                    displayTitles = string.Join(',', borrowedBookTitles);
                }



                Console.WriteLine("{0,-20} {1,-15} {2,-15}", user.Name, user.UserId, displayTitles, "\n");
            }
        }

        public void LendUserBook(User user, Book book)
        {

            if (!UserBooks.ContainsKey(user))
            {

                Console.WriteLine("User has no borrowed books\n");
                UserBooks.Add(user, [book]);
                book.SetBorrowed();
                user.BorrowedBooks.Add(book);

                Console.WriteLine("User borrowed books: \n");
                foreach (var b in user.BorrowedBooks)
                {
                    Console.WriteLine(b.Title);
                }

            }
            else
            {
                Console.WriteLine("User already has borrowed books, add another book\n");
                UserBooks[user].Add(book);
                book.SetBorrowed();
                user.BorrowedBooks.Add(book);

                // list their borrowed books
                Console.WriteLine("User borrowed books: \n");
                foreach (var b in user.BorrowedBooks)
                {
                    Console.WriteLine(b.Title);
                }
            }

        }

        public void ReturnUserBook(User user, Book book)
        {
            if (UserBooks.ContainsKey(user))
            {
                UserBooks[user].Remove(book);
                book.SetReturned();
                user.BorrowedBooks.Remove(book);
            }
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

    }
}