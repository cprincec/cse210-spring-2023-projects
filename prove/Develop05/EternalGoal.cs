using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EternalGoal : Goal
{
    // private DateTime _lastRecordedDate;
    private int _numOfTimesAccomplished;

    public EternalGoal(string name, string desc, int basePoint) : base(name, desc, basePoint)
    {
        // _lastRecordedDate = DateTime.Now;
        _numOfTimesAccomplished = 0;
    }

    public override int RecordEvent()
    {
        _numOfTimesAccomplished++;
        return BasePoint;
    }

    public int CheckProgress()
    {
        return _numOfTimesAccomplished;
    }
}
