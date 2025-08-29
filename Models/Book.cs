namespace LibraryManagementSystem.Models
{

    public interface IBorrowable
    {
        void SetBorrowed();
        void SetReturned();
    }
    public class Book(string title, string author, int isbn, bool isBorrowed) : IBorrowable
    {
        public string Title { get; } = title;
        public string Author { get; } = author;
        public int ISBN { get; } = isbn;
        public bool IsBorrowed { get; private set; } = isBorrowed;


        public void SetBorrowed() => IsBorrowed = true;
        public void SetReturned() => IsBorrowed = false;

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}, IsBorrowed: {IsBorrowed}";
        }

    }
}
