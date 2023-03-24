 public class Book
    {
        public string Title;
        public string Author;
        public string ISBN;
        public Category Category;
        public Publisher Publisher;

        public Book(
            string title,
            string author,
            string isbn,
            Category category,
            Publisher publisher
        )
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Category = category;
            Publisher = publisher;
        }

  
    }

     public class Borrowing
    {
        public User User;
        public Book Book;
        public DateTime BorrowDate;
        public DateTime DueDate;
        public DateTime ReturnDate;

        public Borrowing(User user, Book book, DateTime borrowDate)
        {
            User = user;
            Book = book;
            BorrowDate = borrowDate;
            DueDate = borrowDate.Add(user.GetBorrowingPeriod());
        }

      

        public void ExtendDueDate()
        {
            DueDate = DueDate.Add(User.GetBorrowingPeriod());
        }

        public void SetReturnDate(DateTime returnDate)
        {
            ReturnDate = returnDate;
        }
    }

    public class Return
    {
        public Borrowing Borrowing;
        public DateTime ReturnDate;

        public Return(Borrowing borrowing, DateTime returnDate)
        {
            Borrowing = borrowing;
            ReturnDate = returnDate;
        }
    }

    public class Reservation
    {
        public User User;
        public Book Book;
        public DateTime ReservationDate;

        public Reservation(User user, Book book, DateTime reservationDate)
        {
            User = user;
            Book = book;
            ReservationDate = reservationDate;
        }

    }


    
    public class Category
    {
        public string Name;
        public string Description;

        public Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }

    public class Publisher
    {
        public string Name;
        public string Address;
        public string ContactInfo;

        public Publisher(string name, string address, string contactInfo)
        {
            Name = name;
            Address = address;
            ContactInfo = contactInfo;
        }
    }