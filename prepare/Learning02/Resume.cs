using System;

public class Resume 
{
    public string _name;
    //or it can be written as "public string _name = ""; Meaning empty string

    //Initialize the list to a new List
    public List<Job> _jobs = new List<Job>();

    public void DisplayResumeDetails()
    {
        
    }
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        //Notice the use of the custom data type "Job in this loop
        foreach (Job job in _jobs)
        {
            //This calls the DisplayDetails method on  each jon
            job.DisplayDetails();  //THIS NEEDS TO  BE FIXED
            //This calls the Display method on each job
            job.Display();
        }
    }
    

}