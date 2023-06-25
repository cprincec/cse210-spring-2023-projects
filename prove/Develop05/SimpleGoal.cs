using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SimpleGoal : Goal
{
    private DateTime _completionDate;

    public SimpleGoal(string name, string desc, int basePoint) : base(name, desc, basePoint)
    {
        _completionDate = DateTime.Now;
    }
}
