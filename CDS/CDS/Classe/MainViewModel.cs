using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Cstj.MvvmToolkit;
using Cstj.MvvmToolkit.Services.Definitions;

namespace CDS
{
    public class MainViewModel:BaseViewModel
    {
          private UserControl _currentView;

        public MainViewModel()
        {
            
        }

        public UserControl CurrentView
        {
            get 
            {
                return _currentView; 
            }
            set 
            {
                RaisePropertyChanging();
                _currentView = value; 
                RaisePropertyChanged();
            }
        }

        public void ChangeView<T>(T view)
        {
            CurrentView = view as UserControl;
        }

    }
}