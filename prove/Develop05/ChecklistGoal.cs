using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ChecklistGoal : Goal
{
    private int _numOfTimesToBeAccomplished;
    private int _bonusPoints;
    private int _progress;

    public ChecklistGoal(string name, string desc, int basePoint, int numOfTimes, int bonus) : base(name, desc, basePoint)
    {
        // _completionDate = DateTime.Now;
        _numOfTimesToBeAccomplished = numOfTimes;
        _bonusPoints = bonus;
        _progress = 0;
    }
    public override int RecordEvent()
    {
        if (_progress == _numOfTimesToBeAccomplished)
        {
            IsComplete = true;
            return BasePoint + _bonusPoints;
        }
        _progress++;
        return BasePoint;
    }

    public string CheckProgress()
    {
        return $"{_progress}/{_numOfTimesToBeAccomplished}";
    }

}
