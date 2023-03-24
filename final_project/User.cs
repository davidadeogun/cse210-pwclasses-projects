 //The abstract user class is the base for the different types of user, and it abstracts the common properties
 //and behaviours of all users, and defines the common properties like _name, _email etc and implements the 
 //GetBorrowingPeriod() method in derived classes by making it abstract.
public abstract class User  //The User class is declared abstract and provides a common base for different types of users.
{
    protected string _name;    //Applies the principle of encapsulation
    protected string _email;
    protected string _phone;
    protected string _userType;

    protected User(string name, string email, string phone, string userType)
    {
        _name = name;
        _email = email;
        _phone = phone;
        _userType = userType;
    }
 //Allows access to the required information without exposing the internal implementation 
 //details of the User class and other derived classes
    public string Name => _name;
    public string Email => _email;
    public string Phone => _phone;
    public string UserType => _userType;

    public abstract TimeSpan GetBorrowingPeriod();  //The GetBorrowingPeriod is abstract in the User Class, which enforces its
}                                                 //implementation in the derived classes.

public class Student : User
{
    protected string _studentID;

    public Student(string name, string email, string phone, string studentID)  // Applies the principle of inheritance
        : base(name, email, phone, "Student")
    {
        _studentID = studentID;
    }

    public string StudentId => _studentID;

    public override TimeSpan GetBorrowingPeriod()   //Applies the principle of polymorphism
    {
        return TimeSpan.FromDays(7); // One week for students
    }
}

public class Teacher : User
{
    protected string _teacherID;

    public Teacher(string name, string email, string phone, string teacherID)
        : base(name, email, phone, "Teacher")
    {
        _teacherID = teacherID;
    }

    public string TeacherId => _teacherID;

    public override TimeSpan GetBorrowingPeriod()
    {
        return TimeSpan.FromDays(14); // Two weeks for teachers
    }
}
