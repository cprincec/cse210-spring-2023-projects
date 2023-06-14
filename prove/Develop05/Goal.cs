using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Develop05
{
    public abstract class Goal
    {
        private int basePoint;
        private string description;
        private bool isComplete;
        private string name;

        public abstract bool CheckCompletionStatus();

        public abstract int RecordEvent();
    }
}