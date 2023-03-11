class EternalGoal : Goal  //derived from Goal
{
    public int _numCompletions { get; set; }

    public EternalGoal(string name, string description, int pointsPerCompletion, int numCompletions)
    {
        _name = name;
        _description = description;
        _pointsPerCompletion = pointsPerCompletion;
        _numCompletions = numCompletions;
    }

   

    public override string GetStatus()
    {
        return $"[ ]";
    }

    public override int RecordEvent()
    {
        _numCompletions++;
        _totalPoints += _pointsPerCompletion;
        return _pointsPerCompletion;
    }

    public override string ToDataString()
    {
        return $"{base.ToDataString()},{_numCompletions}";
    }
}