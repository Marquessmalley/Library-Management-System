namespace LibrarayManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Entry point for the Library Management System application
            Console.WriteLine("Welcome to the Library Management System!");
        }
    }

    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int ISBN { get; set; }
        public bool IsBorrowed { get; set; }
    }
}