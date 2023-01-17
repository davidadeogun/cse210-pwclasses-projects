using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");
        
        //call the function "JobInfo()" and pass in the values
        Job job = new Job();
        job._companyName = "Microsoft";
        job._jobTitle = "Software Engineer";
        job._startYear = 2019;
        job._endyear = 2022;
        job.Display();

        Console.WriteLine(); //Leave a space between the ouput.

        Job job1 = new Job();
        job1._companyName = "Apple";
        job1._jobTitle = "Data Engineer";
        job1._startYear =  2011;
        job1._endyear = 2019;
        job1.Display();
    }
}

public class Job 
{
    public string _jobTitle = "";
    public string _companyName = "";

    public int _startYear;
    
    public int _endyear;

    public Job()
    {

    }

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_companyName}) {_startYear}-{_endyear}");
    }

    

}
