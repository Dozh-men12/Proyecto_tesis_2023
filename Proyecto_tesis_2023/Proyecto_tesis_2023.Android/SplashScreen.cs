using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proyecto_tesis_2023.Droid
{

    [Activity(Label = "Proyecto_tesis_2023", Icon = "@mipmap/icon",
        Theme = "@style/splash", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));

        }
    }
}