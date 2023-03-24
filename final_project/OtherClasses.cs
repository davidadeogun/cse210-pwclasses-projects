 public class Book
    {
        public string _title;
        public string _author;
        public string _iSBN;
        public Category _category;
        public Publisher _publisher;

        public Book(
            string title,
            string author,
            string isbn,
            Category category,
            Publisher publisher
        )
        {
            _title = title;
            _author = author;
            _iSBN = isbn;
            _category = category;
            _publisher = publisher;
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
        public string _name;
        public string _description;

        public Category(string name, string description)
        {
            this._name = name;
            this._description = description;
        }
    }

    public class Publisher
    {
        public string _name;
        public string _address;
        public string _contactInfo;

        public Publisher(string name, string address, string contactInfo)
        {
            this._name = name;
            this._address = address;
            this._contactInfo = contactInfo;
        }
    }