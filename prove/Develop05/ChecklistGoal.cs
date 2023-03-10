class ChecklistGoal : Goal
{
    private int v1;
    private int v2;

    public int TargetNumCompletions { get; set; }
public int NumCompletions { get; set; }
public int BonusPoints { get; set; }
public ChecklistGoal(string name, string description, int pointsPerCompletion, int targetNumCompletions, int numCompletions, int bonusPoints)
{
    Name = name;
    Description = description;
    PointsPerCompletion = pointsPerCompletion;
    TargetNumCompletions = targetNumCompletions;
    NumCompletions = numCompletions;
    BonusPoints = bonusPoints;
    
}

    public ChecklistGoal(string name, string description, int pointsPerCompletion, int v1, int v2)
    {
        Name = name;
        Description = description;
        PointsPerCompletion = pointsPerCompletion;
        this.v1 = v1;
        this.v2 = v2;
    }

    public override string GetStatus()
{
    return NumCompletions >= TargetNumCompletions ? "[X]" : "[ ]";
}

public override int RecordEvent()
{
    NumCompletions++;
    TotalPoints += PointsPerCompletion;

    if (NumCompletions == TargetNumCompletions)
    {
        TotalPoints += BonusPoints;
    }

    return PointsPerCompletion;
}

public override string ToDataString()
{
    return $"{base.ToDataString()},{TargetNumCompletions},{NumCompletions},{BonusPoints}";
}
}