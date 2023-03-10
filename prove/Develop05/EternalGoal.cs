// Eternal goal that is never complete
class EternalGoal : Goal
{
    public int NumCompletions { get; set; }

    public override string GetStatus()
    {
        //return IsCompleted ? "[X]" : "[ ]";
        //return $"Completed {NumCompletions} times";
        return $"[ ]";
    }

    public override int RecordEvent()
    {
        NumCompletions++;
        TotalPoints += PointsPerCompletion;
        return PointsPerCompletion;
    }
}