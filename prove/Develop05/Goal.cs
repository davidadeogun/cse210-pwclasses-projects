class Goal
{
public string Name { get; set; }
public string Description { get; set; }
public int PointsPerCompletion { get; set; }
public int TotalPoints { get; set; }
public virtual string GetStatus()
{
    return "";
}

public virtual int RecordEvent()
{
    TotalPoints += PointsPerCompletion;
    return PointsPerCompletion;
}

public virtual string ToDataString()
{
    return $"{GetType().Name},{Name},{Description},{PointsPerCompletion},{TotalPoints}";
}
}