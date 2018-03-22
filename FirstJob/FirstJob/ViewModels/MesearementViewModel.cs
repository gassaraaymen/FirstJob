using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using FirstJob.Annotations;
using FirstJob.Models;
using SL;
using Xamarin.Forms;

namespace FirstJob.ViewModels
{
   public  class MesearementViewModel : INotifyPropertyChanged
    {
        public INavigation _nav;
        public IDataStore<Models.Mesearement> MesearementDataStore => DependencyService.Get<IDataStore<Models.Mesearement>>() ?? new DataStore<Models.Mesearement>("DataBase.db3");
        private readonly IDependencyService _dependencyService;

        public MesearementViewModel() : this(new DependencyServiceWrapper())
        {
        }
        public MesearementViewModel(INavigation nav)
        {

            _nav = nav;
            CurrentPage = DependencyInject<MainPage>.Get();
            OpenPage();
        }

        public MesearementViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;

        }

        public void OpenPage()
        {
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                _nav.PushAsync(CurrentPage);
            }
        }

        public string _height;

        public string Height
        {
            get
            {
                return _height;

            }
            set
            { 
            _height = value;
                OnPropertyChanged();
            }
        }


        public string _width;

        public string Width
        {
            get
            {
                return _width;

            }
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        public string _depth;

        public string Depth
        {
            get
            {
                return _depth;

            }
            set
            {
                _depth = value;
                OnPropertyChanged();
            }
        }



        #region CurrentPage
        Page _currentPage;
        private DependencyServiceWrapper dependencyServiceWrapper;

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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public ICommand VALIDATE
        {
            get
            {
                return new Command(async () =>
                {
                    var u = await MesearementDataStore.GetAllAsync();

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

    }
}
