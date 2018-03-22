using System;
using FirstJob;
using FirstJob.Models;
using FirstJob.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Forms;
namespace Test
{
    
    [TestClass]
    public class UnitTest1
    {
        private IDependencyService _dependencyService;
        Xamarin.Forms.Page c =new MainPage();
        [TestMethod]
        public void TestMethod1()
        {
            // var vm = new ColorViewModel(_dependencyService);
            //Assert.IsNotNull(vm.SAVE);

            

            //var vm = new MesearementViewModel(_dependencyService);
            //vm._nav = c.Navigation;
            //Assert.IsNotNull(vm.VALIDATE);
           // Assert.IsNotNull(vm._nav,"Error nullable navigation");


            var vm = new ProductViewModel(_dependencyService);
            vm._nav = c.Navigation;
            //Assert.IsNotNull(vm.AddCommand);
            //Assert.IsNotNull(vm._nav, "Error nullable navigation");

        }


       
        public void Setup()
        {
            _dependencyService = new DependencyServiceStub();
        }
    }
    
}
