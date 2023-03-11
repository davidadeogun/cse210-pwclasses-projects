class SimpleGoal : Goal
{
    public bool _IsCompleted { get; set; }
    public SimpleGoal(string name, string description, int pointsPerCompletion, bool isCompleted)
    {
        _name = name;
        _description = description;
        _pointsPerCompletion = pointsPerCompletion;
        _IsCompleted = isCompleted;
    }

    public SimpleGoal(string name, string description, int pointsPerCompletion)
    {
        _name = name;
        _description = description;
        _pointsPerCompletion = pointsPerCompletion;
    }

    public override string GetStatus()
    {
        return _IsCompleted ? "[X]" : "[ ]";
    }

    public override int RecordEvent()
    {
        if (!_IsCompleted)
        {
            _IsCompleted = true;
            _totalPoints += _pointsPerCompletion;
            return _pointsPerCompletion;
        }
        else
        {
            return 0;
        }
    }

    public override string ToDataString()
    {
        return $"{base.ToDataString()},{_IsCompleted}";
    }
}
