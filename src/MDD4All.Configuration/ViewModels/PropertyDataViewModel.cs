/*
 * Copyright (c) MDD4All.de, Dr. Oliver Alt
 */
using GalaSoft.MvvmLight;
using System.Reflection;

namespace MDD4All.Configuration.ViewModels
{
    public class PropertyDataViewModel: ViewModelBase
    {

        private object _parentObject;

        private PropertyInfo _propertyInfo;

        public PropertyDataViewModel(PropertyInfo propertyInfo, object parentObject)
        {
            _propertyInfo = propertyInfo;
            _parentObject = parentObject;
        }


        public string Name 
        { 
            get
            {
                string result = string.Empty;

                if(_propertyInfo != null)
                {
                    result = _propertyInfo.Name;
                }

                return result;
            }
            
            
        }

        public string Value
        {
            get
            {
                string result = string.Empty;

                if (_propertyInfo != null)
                {
                    object propertyObject = _propertyInfo.GetValue(_parentObject, null);
                    string propertyValue = propertyObject == null ? string.Empty : propertyObject.ToString();

                    if (Name.ToLower().Contains("apikey") ||
                        Name.ToLower().Contains("password") ||
                        Name.ToLower().Contains("secret"))
                    {
                        result = "********";
                    }
                    else
                    {

                        result = propertyValue;
                    }
                }

                return result;
            }

            set
            {
                _propertyInfo.SetValue(_parentObject, value);

                

                RaisePropertyChanged("Value");
            }
        }
    }
}
