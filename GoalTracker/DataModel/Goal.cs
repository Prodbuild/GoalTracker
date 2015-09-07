using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GoalTracker.DataModel
{
    public class Goal
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ObservableCollection<DateTime> Dates { get; set; }
    }
}
