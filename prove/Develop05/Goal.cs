class Goal
{
    internal string Description;

    public string Name { get; set; }
    public int PointsPerCompletion { get; set; }
    public int TotalPoints { get; set; }

    // This method is overriden by derived classes as needed
    public virtual string GetStatus()
    {
        return "";
    }

    // This method is called when the user records an event for this goal
    public virtual int RecordEvent()
    {
        TotalPoints += PointsPerCompletion;
        return PointsPerCompletion;
    }
}