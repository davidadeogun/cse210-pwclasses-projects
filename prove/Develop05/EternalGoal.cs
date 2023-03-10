class EternalGoal : Goal
{
    public int NumCompletions { get; set; }

    public EternalGoal(string name, string description, int pointsPerCompletion, int numCompletions)
    {
        Name = name;
        Description = description;
        PointsPerCompletion = pointsPerCompletion;
        NumCompletions = numCompletions;
    }

   

    public override string GetStatus()
    {
        return $"[ ]";
    }

    public override int RecordEvent()
    {
        NumCompletions++;
        TotalPoints += PointsPerCompletion;
        return PointsPerCompletion;
    }

    public override string ToDataString()
    {
        return $"{base.ToDataString()},{NumCompletions}";
    }
}
