//The AddProgressGoal is a derived class of the Goal
// class that represents a goal that can be achieved by making progress towards a specific target value

class AddProgressGoal : Goal
{
    public int _targetProgress { get; set; }
    public new int _progress { get; set; }

    public AddProgressGoal(string name, string description, int pointsPerCompletion, int targetProgress)
    {
        _name = name;
        _description = description;
        _pointsPerCompletion = pointsPerCompletion;
        _targetProgress = targetProgress;
        _progress = 0;
    }

    public override string GetStatus()
    {
        return $"Progress: {_progress}/{_targetProgress}";
    }

    public override int RecordEvent()
    {
        _progress += _pointsPerCompletion;
        _totalPoints += _pointsPerCompletion;

        if (_progress >= _targetProgress)
        {
            _progress = _targetProgress;
        }

        return _pointsPerCompletion;
    }

    public override string ToDataString()
    {
        return $"{base.ToDataString()},{_targetProgress},{_progress}";
    }
//The AddProgress() method, which is a new method added to the
// AddProgressGoal class, allows progress to be added to the goal outside of the RecordEvent() method.
    public override void AddProgress(int amount)
    {
        _progress += amount;

        if (_progress >= _targetProgress)
        {
            _progress = _targetProgress;
        }
    }
}
