/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using MDD4All.Configuration.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace MDD4All.Configuration.Views
{

    public partial class PropertyDialog : Window
    {
        private ObservableCollection<PropertyDataViewModel> _propertyDataViewModels = new ObservableCollection<PropertyDataViewModel>();

        public PropertyDialog()
        {
            InitializeComponent();
        }

        public void SetPropertyData(object data)
        {
            Type configurationObjectType = data.GetType();

            _propertyDataViewModels.Clear();

            foreach (PropertyInfo propertyInfo in configurationObjectType.GetProperties())
            {
                PropertyDataViewModel propertyDataViewModel = new PropertyDataViewModel(propertyInfo, data);

                _propertyDataViewModels.Add(propertyDataViewModel);
                
            }

            _propertyGrid.DataContext = _propertyDataViewModels;
        }
    }
}
