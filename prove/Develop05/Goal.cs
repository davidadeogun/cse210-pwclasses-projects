class Goal
{
    public string _name { get; set; }
    public string _description { get; set; }
    public int _pointsPerCompletion { get; set; }
    public int _totalPoints { get; set; }
    public virtual string GetStatus()
    {
        return "";
    }

    public virtual int RecordEvent()
    {
        _totalPoints += _pointsPerCompletion;
        return _pointsPerCompletion;
    }

    public virtual string ToDataString()
    {
        return $"{GetType().Name},{_name},{_description},{_pointsPerCompletion},{_totalPoints}";
    }
}
