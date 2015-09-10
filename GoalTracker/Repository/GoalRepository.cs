using GoalTracker.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.IO;

namespace GoalTracker.Repository
{
    public class GoalRepository
    {
        private ObservableCollection<Goal> _goals;
        private const string _fileName = "goalList.json";

        public GoalRepository()
        {
            this._goals = new ObservableCollection<Goal>();
        }

        private async Task EnsureGoalsLoaded()
        {
            if (!this._goals.Any())
            {
                await this.GetGoalDataAsync();
            }
        }

        private async Task GetGoalDataAsync()
        {
            if (this._goals.Any())
            {
                return;
            }

            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Goal>));

            try
            {
                using (var fileStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(_fileName))
                {
                    this._goals = (ObservableCollection<Goal>)serializer.ReadObject(fileStream);
                }
            }
            catch
            {
                this._goals = new ObservableCollection<Goal>();
            }

        }

        private async Task SaveGoalDataAsync()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(ObservableCollection<Goal>));

            using (var fileStream =
                await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(_fileName, CreationCollisionOption.ReplaceExisting))
            {
                jsonSerializer.WriteObject(fileStream, this._goals);
            }
        }

        public async void AddGoal(string goalName, string goalDescription)
        {
            var goal = new Goal
            {
                Name = goalName,
                Description = goalDescription,
                Dates = new ObservableCollection<DateTime>()
            };

            this._goals.Add(goal);
            await SaveGoalDataAsync();

        }

        public async Task<ObservableCollection<Goal>> GetGoals()
        {
            await EnsureGoalsLoaded();
            return this._goals;
        }

        public async void CompletedGoalToday(Goal goalInstance)
        {
            var index = this._goals.IndexOf(goalInstance);
            this._goals[index].AddDate();
            await this.SaveGoalDataAsync();
        }
    }
}
