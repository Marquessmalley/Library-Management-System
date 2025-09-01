namespace LibraryManagementSystem.Models
{
    public class User(string name, int userId, List<Book> borrowedBooks)
    {
        public string Name { get; } = name;
        public int UserId { get; } = userId;
        public List<Book> BorrowedBooks { get; set; } = borrowedBooks;
        // public List<Book> MyBooks { get; } = []

    }
}