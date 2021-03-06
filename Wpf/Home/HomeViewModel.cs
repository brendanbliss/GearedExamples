﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using Geared.Wpf.Intro;
using DynamicAxisUnitView = Geared.Wpf.DynamicAxisUnit.DynamicAxisUnitView;
using FinancialSeriesView = Geared.Wpf.FianancialSeries.FinancialSeriesView;
using HistogramView = Geared.Wpf.Histogram.HistogramView;
using MultipleSeriesView = Geared.Wpf.MultipleSeriesTest.MultipleSeriesView;
using ScatterView = Geared.Wpf.Scatter.ScatterView;
using ScrollableView = Geared.Wpf.Scrollable.ScrollableView;
using SpeedTestView = Geared.Wpf.SpeedTest.SpeedTestView;
using StackedSeriesView = Geared.Wpf.StackedSeries.StackedSeriesView;
using TestingGearedView = Geared.Wpf.Testing_Geared.TestingGearedView;

namespace Geared.Wpf.Home
{
    public class HomeViewModel: INotifyPropertyChanged
    {
        private UserControl _content;
        private bool _isMenuOpen;

        public HomeViewModel()
        {
            IsMenuOpen = true;
            Samples = new ObservableCollection<SampleVm>
            {
                new SampleVm
                {
                    Title = "Intro",
                    Content = typeof(IntroView)
                },
                new SampleVm
                {
                    Title = "Testing Geared",
                    Content = typeof(TestingGearedView)
                },
                new SampleVm
                {
                    Title = "Multi-thread speed Test",
                    Content = typeof(SpeedTestView)
                },
                new SampleVm
                {
                    Title = "Multiple Series",
                    Content = typeof(MultipleSeriesView)
                },
                new SampleVm
                {
                    Title = "Scrollable",
                    Content = typeof(ScrollableView)
                },
                new SampleVm
                {
                    Title = "Histogram",
                    Content = typeof(HistogramView)
                },
                new SampleVm
                {
                    Title = "Dynamic Axis",
                    Content = typeof(DynamicAxisUnitView)
                },
                new SampleVm
                {
                    Title = "Financial Series",
                    Content = typeof(FinancialSeriesView)
                },
                new SampleVm
                {
                    Title = "Scatter",
                    Content = typeof(ScatterView)
                },
                new SampleVm
                {
                    Title = "Adding many pts per read",
                    Content = typeof(StackedSeriesView)
                }
            };

            Content = (UserControl) Activator.CreateInstance( Samples[0].Content);
        }

        public ObservableCollection<SampleVm> Samples { get; set; }
        public UserControl Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }
        public bool IsMenuOpen
        {
            get { return _isMenuOpen; }
            set
            {
                _isMenuOpen = value;
                OnPropertyChanged("IsMenuOpen");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class IsNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
