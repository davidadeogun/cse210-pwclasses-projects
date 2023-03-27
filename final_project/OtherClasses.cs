 public class Book
    {
        private string _title;     //attributes
        private string _author;
        private string _iSBN;
        public Category _category;
        public Publisher _publisher;

        public Book(     //constructor
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
 //Allows access to the required information without exposing the internal implementation 
  public string Title => _title;
  public string Author => _author;

  public string ISBN => _iSBN;
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
        private string _name;
        private string _description;

        public Category(string name, string description)
        {
            this._name = name;
            this._description = description;
        }

 //Allows access to the required information without exposing the internal implementation 
        public string Name => _name;
        public string Description => _description;
    }

    public class Publisher
    {
        private string _name;      //attributes
        private string _address;
        private string _contactInfo;

        public Publisher(string name, string address, string contactInfo)   //constructor
        {
            this._name = name;
            this._address = address;
            this._contactInfo = contactInfo;
        }

        public string Name => _name;
        public string Address => _address;
        public string ContactInfo => _contactInfo;
    }