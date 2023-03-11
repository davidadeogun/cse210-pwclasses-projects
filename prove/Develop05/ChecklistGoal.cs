class ChecklistGoal : Goal  //derived from Goal
{
    private int _verse1;
    private int _verse2;

    public int _targetNumCompletions { get; set; }
public int _numCompletions { get; set; }
public int _bonusPoints { get; set; }
public ChecklistGoal(string name, string description, int pointsPerCompletion, int targetNumCompletions, int numCompletions, int bonusPoints)
{
    _name = name;
    _description = description;
    _pointsPerCompletion = pointsPerCompletion;
    _targetNumCompletions = targetNumCompletions;
    _numCompletions = numCompletions;
    _bonusPoints = bonusPoints;
    
}

    public ChecklistGoal(string name, string description, int pointsPerCompletion, int v1, int v2)
    {
        _name = name;
        _description = description;
        _pointsPerCompletion = pointsPerCompletion;
        _verse1 = v1;
        _verse2 = v2;
    }

    public override string GetStatus()
{
    return _numCompletions >= _targetNumCompletions ? "[X]" : "[ ]";
}

public override int RecordEvent()
{
    _numCompletions++;
    _totalPoints += _pointsPerCompletion;

    if (_numCompletions == _targetNumCompletions)
    {
        _totalPoints += _bonusPoints;
    }

    return _pointsPerCompletion;
}

public override string ToDataString()
{
    return $"{base.ToDataString()},{_targetNumCompletions},{_numCompletions},{_bonusPoints}";
}
}