using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirstJob.ViewModels;
using Xamarin.Forms;
using Page = Xamarin.Forms.PlatformConfiguration.WindowsSpecific.Page;

namespace FirstJob
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    var model = DependencyInject<ProductViewModel>.Get();
		    model.CurrentPage = DependencyInject<MainPage>.Get();
		    model.CurrentPage.BindingContext = model;
		    var nav = new NavigationPage(model.CurrentPage);
		    model._nav = nav.Navigation;
		    MainPage = nav;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
