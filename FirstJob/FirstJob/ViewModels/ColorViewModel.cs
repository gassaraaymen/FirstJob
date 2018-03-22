using FirstJob.Models;
using SL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using FirstJob.ViewModels;

namespace FirstJob.ViewModels
{
    public class ColorViewModel : INotifyPropertyChanged
    {
        public INavigation _nav;
        public IDataStore<Models.Color> ColorDataStore => DependencyService.Get<IDataStore<Models.Color>>() ?? new DataStore<Models.Color>("DataBase.db3");
        private readonly IDependencyService _dependencyService;



        public ColorViewModel() : this(new DependencyServiceWrapper())
        {
        }
        public ColorViewModel(INavigation nav)
        {

            _nav = nav;
            CurrentPage = DependencyInject<MainPage>.Get();
            OpenPage();
        }


        public void OpenPage()
        {
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                _nav.PushAsync(CurrentPage);
            }
        }

        public ColorViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
        }


        public string _colorcode;
        public string Colorcode
        {
            get
            {
                return _colorcode;
            }
            set
            {
                _colorcode = value;
                OnPropertyChanged();
            }
        }
        public string _colorname;
        public string Colorname
        {
            get
            {
                return _colorname;
            }
            set
            {
                _colorname = value;
                OnPropertyChanged();
            }
        }

        #region CurrentPage
        Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand VALIDATE
        {
            get
            {
                return new Command(async () =>
                {
                    var u = await ColorDataStore.GetAllAsync();

                    if (u.Count() > 0)
                    {

                        await CurrentPage.DisplayAlert("Notification !..", "Welcome ..", "Ok ..");
                        //var ss = DependencyService.Get<ColorViewModel>() ?? (new ViewModels.ColorViewModel(_nav));

                    }
                    else
                    {
                        await CurrentPage.DisplayAlert("Error !..", "No Data ..", "Ok ..");
                    }
                });
            }
        }

        public ICommand SAVE
        {
            get
            {
                Models.Color color = new Models.Color();
                color.Colorcode = _colorcode;
                color.Colorname = _colorname;

                return new Command(async () =>
                {
                    var u = await ColorDataStore.AddAsync(color);
                        await CurrentPage.DisplayAlert("Success !..", ":D ..", "Ok ..");
                });
            }
        }
        
    }
}
