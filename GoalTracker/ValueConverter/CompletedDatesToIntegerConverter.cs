﻿using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Data;

namespace GoalTracker.ValueConverter
{
    class CompletedDatesToIntegerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ObservableCollection<DateTime> dates = (ObservableCollection<DateTime>)value;
            return dates.Count;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
