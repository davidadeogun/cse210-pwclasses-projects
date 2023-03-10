class ChecklistGoal : Goal
{
    public int TargetNumCompletions { get; set; }
    public int NumCompletions { get; set; }
    public int bonusPoints { get; private set; }

 public override string GetStatus()
{
    return NumCompletions >= TargetNumCompletions ? $"[X]" : $"[ ]";
}


    public override int RecordEvent()
    {
       NumCompletions++;
    TotalPoints += PointsPerCompletion;

    int bonusPoints = 0;
    int completeAmount = TargetNumCompletions;

    if (NumCompletions == completeAmount)
    {
        TotalPoints += bonusPoints;
    }

    return PointsPerCompletion;
    }

}