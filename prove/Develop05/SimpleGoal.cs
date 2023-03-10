// Simple goal that can be marked complete
class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; }

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
}