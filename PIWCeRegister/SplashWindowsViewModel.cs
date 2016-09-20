using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace PIWCeRegister
{
    class SplashWindowsViewModel:ViewModelBase
    {
        private string _splashScreenText = "Initializing...";
        public string SplashScreenText
        {
            get { return _splashScreenText; }
            set
            {
                _splashScreenText = value;
                RaisePropertyChanged(() => SplashScreenText);
            }
        }
    }
}
