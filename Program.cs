namespace LibrarayManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Entry point for the Library Management System application
            Console.WriteLine("Welcome to the Library Management System!");

            Book book1 = new Book("Green Eggs & Ham", "Dr. Seuss", 123456, false);



        }
    }

    public class Book(string title, string author, int isbn, bool isBorrowed)
    {
        public string Title { get; } = title;
        public string Author { get; } = author;
        public int ISBN { get; } = isbn;
        public bool IsBorrowed { get; set; } = isBorrowed;
    }
}