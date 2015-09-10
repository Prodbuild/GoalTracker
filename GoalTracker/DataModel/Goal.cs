using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GoalTracker.Commands;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace GoalTracker.DataModel
{
    public class Goal : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ObservableCollection<DateTime> Dates { get; set; }

        [IgnoreDataMember]
        public ICommand CompletedCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public Goal()
        {
            this.CompletedCommand = new CompletedButtonCommand();
            this.Dates = new ObservableCollection<DateTime>();
        }

        public void AddDate()
        {
            this.Dates.Add(DateTime.Today);
            this.NotifyPropertyChanged("Dates");
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
