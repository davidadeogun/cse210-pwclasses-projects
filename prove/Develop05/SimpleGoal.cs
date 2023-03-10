class SimpleGoal : Goal
{
public bool IsCompleted { get; set; }
public SimpleGoal(string name, string description, int pointsPerCompletion, bool isCompleted)
{
    Name = name;
    Description = description;
    PointsPerCompletion = pointsPerCompletion;
    IsCompleted = isCompleted;
}

    public SimpleGoal(string name, string description, int pointsPerCompletion)
    {
        Name = name;
        Description = description;
        PointsPerCompletion = pointsPerCompletion;
    }

    public override string GetStatus()
{
    return IsCompleted ? "[X]" : "[ ]";
}

public override int RecordEvent()
{
    if (!IsCompleted)
    {
        IsCompleted = true;
        TotalPoints += PointsPerCompletion;
        return PointsPerCompletion;
    }
    else
    {
        return 0;
    }
}

public override string ToDataString()
{
    return $"{base.ToDataString()},{IsCompleted}";
}
}