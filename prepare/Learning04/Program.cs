using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("David Ade", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }

    public class Assignment
    {
        protected string _studentName;
        protected string _topic;

        public Assignment(string studentName, string topic)
        {
            this._studentName = studentName;
            this._topic = topic;
        }

        public string GetStudentName()
        {
            return _studentName;
        }

        public string GetTopic()
        {
            return _topic;
        }

        public string GetSummary()
        {
            return $"{_studentName} {_topic}";
        }
    }

    public class WritingAssignment : Assignment
    {
        private string _title;

        public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
        {
            this._title = title;
        }

        public string GetWritingInformation()
        {
            return $"{_title} by {_studentName}";
        }
    }

    public class MathAssignment : Assignment
    {
        private string _textbookSection;
        private string _problems;

        public MathAssignment(string studentName, string topic, string textbookSection, string problems)
            : base(studentName, topic)
        {
            this._textbookSection = textbookSection;
            this._problems = problems;
        }

        public string GetHomeworkList()
        {
            return $"Section {_textbookSection} Problems {_problems}";
        }
    }
}
