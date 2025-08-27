# Library-Management-System(OOP-Demonstration)

## Scope

Create a console-based library system where you manage books, users, and borrowing records. This will test your ability to design classes, implement inheritance, interfaces, and encapsulation.

## Requirements

### Classes

- **Book** (Properties: title, author, ISBN, isBorrowed)
- **User** (Properties: name, userId, borrowedBooks)
- **Library** (Methods to add/remove books, lend books, return books)
- **Optional:** PremiumUser inherits from User with extra borrowing privileges

### Encapsulation

- Prevent direct modification of book availability outside the Library class.

### Inheritance & Polymorphism

- Different user types (RegularUser, PremiumUser) with overridden borrowing limits.

### Collections

- Use `List<Book>` and `Dictionary<User, List<Book>>` to manage inventory and loans.

### Interface

- Create an `IBorrowable` interface implemented by Book (methods: `Borrow()`, `Return()`)

## Expected Output

- Add new books to the library and list all available books.
- Register users and show their borrowed books.
- Lend a book to a user and update the availability.
- Return a book and reflect changes in both the user’s borrowed list and library inventory.
- Display messages if a user tries to borrow more than allowed or if a book is unavailable.
