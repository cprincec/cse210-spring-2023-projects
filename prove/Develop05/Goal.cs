using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Goal
{
    private int _basePoint;
    private string _description;
    private bool _isComplete;
    private string _name;

    public Goal(string name, string desc, int basePoint)
    {
        _name = name;
        _description = desc;
        _basePoint = basePoint;
        _isComplete = false;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int BasePoint
    {
        get => _basePoint;
        set => _basePoint = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public bool IsComplete
    {
        get => _isComplete;
        set => _isComplete = value;
    }

    public virtual int RecordEvent()
    {
        IsComplete = true;
        return BasePoint;
    }
}
