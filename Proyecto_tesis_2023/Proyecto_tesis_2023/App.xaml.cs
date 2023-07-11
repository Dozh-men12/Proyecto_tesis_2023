    using Proyecto_tesis_2023.View;
    using Proyecto_tesis_2023.View.Tabbed;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    namespace Proyecto_tesis_2023
    {
        public partial class App : Application
        {
            public App()
            {
                InitializeComponent();
            MainPage = new ContainerTabbedPage();

            //MainPage = new NavigationPage(new Login());
            }

            protected override void OnStart()
            {
            }

            protected override void OnSleep()
            {
            }

            protected override void OnResume()
            {
            }
        }
    }
