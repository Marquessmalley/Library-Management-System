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

            Console.WriteLine("{0,-20} {1,-15} {2, -15} {3, -12}", "Title", "Author", "ISBN", "Checked Out\n");
            foreach (var book in Books)
            {
                Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-12}", book.Title, book.Author, book.ISBN, book.IsBorrowed, "\n");
            }
        }

        public void LendUserBook(User user, Book book)
        {

            if (UserBooks.ContainsKey(user))
            {
                // User already has borrowed books, add another book
                UserBooks[user].Add(book);
                book.SetBorrowed();
                user.BorrowedBooks.Add(book);

            }
            else
            {
                // User has no borrowed books, create a new entry
                Console.WriteLine("Use has no borrowed books, creating a new entry.");
                UserBooks.Add(user, [book]);
                book.SetBorrowed();
                user.BorrowedBooks.Add(book);
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

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public void ListUsers()
        {
            Console.WriteLine("{0,-20} {1,-15} {2, -15}", "Name", "User ID", "Borrowed Books\n");
            foreach (var user in Users)
            {
                Console.WriteLine("{0,-20} {1,-15} {2,-15}", user.Name, user.UserId, user.BorrowedBooks, "\n");
            }
        }
    }
}