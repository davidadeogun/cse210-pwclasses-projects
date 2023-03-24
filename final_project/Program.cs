using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//This is a virtual library management application that allows a librarian to manage the 
//the inventory and members of a library. The librarian can register as many books before they become available to be 
//reserved, borrowed or returned. Also, only registered users (teacher or student) can borrow a book from the library.
//There are many more features that for a complete library management application,but the functionalities would be almost
//exhaustive. 

namespace LibraryManagementSystem
{
    public class Program
    {
        public static List<Book> Books = new List<Book>();
        public static List<User> Users = new List<User>();
        public static List<Borrowing> Borrowings = new List<Borrowing>();
        public static List<Return> Returns = new List<Return>();
        public static List<Reservation> Reservations = new List<Reservation>();

        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to the Virtual Library Management Application");
            int choice;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine();
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. Register a new user");
                Console.WriteLine("3. Borrow a book");
                Console.WriteLine("4. Return a book");
                Console.WriteLine("5. Reserve a book");
                Console.WriteLine("6. View book details");
                Console.WriteLine("7. View user details");
                Console.WriteLine("8. View borrowing history");
                Console.WriteLine("9. Extend due date for a borrowed book");

                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewBook();
                        break;
                    case 2:
                        RegisterNewUser();
                        break;
                    case 3:
                        BorrowBook();
                        break;
                    case 4:
                        ReturnBook();
                        break;
                    case 5:
                        ReserveBook();
                        break;
                    case 6:
                        ViewBookDetails();
                        break;
                    case 7:
                        ViewUserDetails();
                        break;
                    case 8:
                        ViewBorrowingHistory();
                        break;
                        case 9:
                        ExtendDueDate();
                        break;
                    case 10:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 10);
        }

        public static void AddNewBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter book author: ");
            string author = Console.ReadLine();

            Console.Write("Enter book ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Enter book category name: ");
            string categoryName = Console.ReadLine();

            Console.Write("Enter book category description: ");
            string categoryDescription = Console.ReadLine();

            Console.Write("Enter publisher name: ");
            string publisherName = Console.ReadLine();

            Console.Write("Enter publisher address: ");
            string publisherAddress = Console.ReadLine();

            Console.Write("Enter publisher phone number: ");
            string publisherContactInfo = Console.ReadLine();

            Category category = new Category(categoryName, categoryDescription);
            Publisher publisher = new Publisher(
                publisherName,
                publisherAddress,
                publisherContactInfo
            );
            Book newBook = new Book(title, author, isbn, category, publisher);

            Books.Add(newBook);
            Console.WriteLine("Book added successfully.");
        }

        public static void RegisterNewUser()
        {
            Console.Write("Enter user type (Student/Teacher): ");
            string userType = Console.ReadLine();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter ID: ");
            string id = Console.ReadLine();

            User newUser;
            if (userType.Equals("Student", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Student(name, email, phone, id);
            }
            else if (userType.Equals("Teacher", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Teacher(name, email, phone, id);
            }
            else
            {
                Console.WriteLine("Invalid user type. Please try again.");
                return;
            }

            Users.Add(newUser);
            Console.WriteLine("User registered successfully.");
        }

        public static void BorrowBook()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();

            User user = Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter book ISBN: ");
            string bookISBN = Console.ReadLine();

            Book book = Books.FirstOrDefault(b => b._iSBN == bookISBN);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            DateTime borrowDate = DateTime.Now;
            Borrowing borrowing = new Borrowing(user, book, borrowDate);

            Borrowings.Add(borrowing);
            Console.WriteLine("Book borrowed successfully.");
        }

        public static void ReturnBook()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();

            User user = Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter book ISBN: ");
            string bookISBN = Console.ReadLine();

            Book book = Books.FirstOrDefault(b => b._iSBN == bookISBN);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Borrowing borrowing = Borrowings.FirstOrDefault(
                b =>
                    b.Book._iSBN == bookISBN
                    && b.User.Email == userEmail
                    && b.ReturnDate == DateTime.MinValue
            );
            if (borrowing == null)
            {
                Console.WriteLine("Borrowing record not found.");
                return;
            }

            DateTime returnDate = DateTime.Now;
            borrowing.SetReturnDate(returnDate);

            Return newReturn = new Return(borrowing, returnDate);
            Returns.Add(newReturn);

            Console.WriteLine("Book returned successfully.");
        }

        public static void ReserveBook()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();

            User user = Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter book ISBN: ");
            string bookISBN = Console.ReadLine();

            Book book = Books.FirstOrDefault(b => b._iSBN == bookISBN);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            DateTime reserveDate = DateTime.Now;
            Reservation reservation = new Reservation(user, book, reserveDate);

            Reservations.Add(reservation);
            Console.WriteLine("Book reserved successfully.");
        }

        public static void ViewBookDetails()
        {
            Console.Write("Enter book ISBN: ");
            string bookISBN = Console.ReadLine();

            Book book = Books.FirstOrDefault(b => b._iSBN == bookISBN);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine($"Title: {book._title}");
            Console.WriteLine($"Author: {book._author}");
            Console.WriteLine($"ISBN: {book._iSBN}");
            Console.WriteLine($"Category: {book._category._name} - {book._category._description}");
            Console.WriteLine($"Publisher: {book._publisher._name}");
            Console.WriteLine($"Publisher Address: {book._publisher._address}");
            Console.WriteLine($"Publisher Phone Number: {book._publisher._contactInfo}");
        }

        public static void ViewUserDetails()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();

            User user = Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            Console.WriteLine();
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone: {user.Phone}");
            Console.WriteLine($"User Type: {user.UserType}");
            if (user is Student student)
            {
                Console.WriteLine($"Student ID: {student.StudentId}");
            }
            else if (user is Teacher teacher)
            {
                Console.WriteLine($"Teacher ID: {teacher.TeacherId}");
            }
        }

        public static void ViewBorrowingHistory()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();

            User user = Users.FirstOrDefault(u => u.Email == userEmail);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            var userBorrowings = Borrowings.Where(b => b.User.Email == userEmail).ToList();

            if (userBorrowings.Count == 0)
            {
                Console.WriteLine("No borrowing history.");
                return;
            }

            Console.WriteLine("Borrowing History:");
            foreach (var borrowing in userBorrowings)
            {
                Console.WriteLine($"Book Title: {borrowing.Book._title}");
                Console.WriteLine($"Borrow Date: {borrowing.BorrowDate.ToShortDateString()}");
                if (borrowing.ReturnDate == DateTime.MinValue)
                {
                    Console.WriteLine("Return Date: Not returned yet");
                }
                else
                {
                    Console.WriteLine($"Return Date: {borrowing.ReturnDate.ToShortDateString()}");
                }
                Console.WriteLine("--------------------------------------------------");
            }
        }

        public static void ExtendDueDate()
{
    Console.Write("Enter user email: ");
    string userEmail = Console.ReadLine();

    User user = Users.FirstOrDefault(u => u.Email == userEmail);
    if (user == null)
    {
        Console.WriteLine("User not found.");
        return;
    }

    Console.Write("Enter book ISBN: ");
    string bookISBN = Console.ReadLine();

    Book book = Books.FirstOrDefault(b => b._iSBN == bookISBN);
    if (book == null)
    {
        Console.WriteLine("Book not found.");
        return;
    }

    Borrowing borrowing = Borrowings.FirstOrDefault(
        b =>
            b.Book._iSBN == bookISBN
            && b.User.Email == userEmail
            && b.ReturnDate == DateTime.MinValue
    );
    if (borrowing == null)
    {
        Console.WriteLine("Borrowing record not found.");
        return;
    }

    borrowing.ExtendDueDate();
    Console.WriteLine("Due date extended successfully.");
}

    }
}
