using Android.App;
using EFXamarin;
using System;
using System.IO;

namespace EFXamarin.Droid
{
    [Activity(Label = "EFXamarin.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MainTheme")]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
        

            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "exrin.db");
            
            LoadApplication(new App(dbPath));
        }
    }
}

