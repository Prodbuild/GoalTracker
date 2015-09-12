using GoalTracker.DataModel;
using System;
using System.Windows.Input;

namespace GoalTracker.Commands
{
    public class GoalsCompletedButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.Repository.CompletedGoalToday((Goal)parameter);
        }
    }
}
