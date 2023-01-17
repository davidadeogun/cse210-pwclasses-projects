using System;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person._givenName = "Joseph";
        person._familyName = "Smith";
        person.ShowWesternName();
        person.ShowEasternName();
        Console.WriteLine("Hello World!");

        Console.WriteLine();
        Person person1  = new Person();
        person1._givenName = "David";
        person1._familyName = "Adeogun";
        person1.ShowEasternName();
        person1.ShowWesternName();
    }
}

public class Person
{
    public string _givenName = "";
    public string _familyName = "";

    public Person()
    {

    }

    public void ShowEasternName()
    {
        Console.WriteLine($"{_familyName},{_givenName}");
    }

    public void ShowWesternName()
    {
        Console.WriteLine($"{_givenName} {_familyName}");
    }


}

