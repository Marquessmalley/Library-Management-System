namespace LibrarayManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Entry point for the Library Management System application
            Console.WriteLine("Welcome to the Library Management System!");

            Book book1 = new Book("Green Eggs & Ham", "Dr. Seuss", 123456, false);
            Book book2 = new Book("The Hidden Gem", "John Doe", 6543231, false);



        }
    }

    public class Book(string title, string author, int isbn, bool isBorrowed)
    {
        public string Title { get; } = title;
        public string Author { get; } = author;
        public int ISBN { get; } = isbn;
        public bool IsBorrowed { get; private set; } = isBorrowed;


    }

    public class User(string name, int userId, int borrowedBooks)
    {
        public string Name { get; } = name;
        public int UserId { get; } = userId;
        public int BorrowedBooks { get; set; } = borrowedBooks;
    }

    public class Library
    {
        public List<Book> Books { get; } = new List<Book>();
    }
}