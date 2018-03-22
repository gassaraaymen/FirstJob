using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ProductViewModel:INotifyPropertyChanged
    {
        public INavigation _nav;

        public ObservableCollection<Product> Products;


        public ObservableCollection<Product> ProductList
        {
            get
            {

                return Products ?? (Products = new ObservableCollection<Product>());
            }
            set
            {
                Products = value;
                OnPropertyChanged();

            }
        }


        public IDataStore<Product> ProductDataStore =>
            DependencyService.Get<IDataStore<Product>>() ?? new DataStore<Product>("DataBase.db3");
        public IDataStore<Models.Color> ColorDataStore => DependencyService.Get<IDataStore<Models.Color>>() ?? new DataStore<Models.Color>("DataBase.db3");
        public IDataStore<Models.Mesearement> MesearementDataStore => DependencyService.Get<IDataStore<Models.Mesearement>>() ?? new DataStore<Models.Mesearement>("DataBase.db3");



        private readonly IDependencyService _dependencyService;

        public ProductViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;

        }


        public ProductViewModel() : this(new DependencyServiceWrapper())
        {
            try
            {
                ColorDataStore.CreateTableAsync21();
                MesearementDataStore.CreateTableAsync21();
                ProductDataStore.CreateTableAsync21();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public ProductViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<MainPage>.Get();
            ColorDataStore.CreateTableAsync21();
            MesearementDataStore.CreateTableAsync21();
            ProductDataStore.CreateTableAsync21();
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

        
        public int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public String _name;

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand GETALL
        {
            get
            {
                return new Command(async () =>
                {
                    var u = await ProductDataStore.GetAllAsync();

                    foreach (var item in u)
                    {
                        ProductList.Add(item);

                    }

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


        #region AddCommand Implementation

        public ICommand AddCommand
        {
            get
            {
                Product p = new Product();


                p.Name = "T-Shirt";
                
                

                return new Command(async () =>
                {
                    try
                    {
                        await ProductDataStore.AddAsync(p);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);

                    }

                });
            }
        }

        #endregion




    }
}
