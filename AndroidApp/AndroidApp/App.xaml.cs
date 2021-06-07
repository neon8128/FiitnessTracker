using AndroidApp.Services;
using AndroidApp.Services.Navigation;
using AndroidApp.Utility;
using AndroidApp.Views;
using Autofac;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidApp
{
    public partial class App : Application
    {
        public static INavigationService NavigationService { get; } = new NavigationService();
        public static IContainer Container;

        public App()
        {
            InitializeComponent();
            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();
            //TODO - register repositories if you use them
            //builder.RegisterType<Repository<User>>().As<IRepository<User>>();

            //get container
            Container = builder.Build();
            //set first page

            //MainPage = new AppShell();

            MainPage = new NavigationPage(new LoginPage());

            //saving the pages in the dictionary for the navigation service
            NavigationService.Configure(ViewNames.LoginPage, typeof(LoginPage));
            NavigationService.Configure(ViewNames.RegisterPage, typeof(RegisterPage));
            NavigationService.Configure(ViewNames.FirstPage, typeof(FirstPage));
            Application.Current.UserAppTheme = OSAppTheme.Light;

        }
    }
}