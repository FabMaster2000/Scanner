using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;
using Android.Content;
using Android.Support.V7.Widget;

namespace Scanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button button_login;
        private EditText un;
        private EditText pw;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set the view
            SetContentView(Resource.Layout.login);

            button_login = FindViewById<Button>(Resource.Id.button_login);
            un = FindViewById<EditText>(Resource.Id.et_username);
            pw = FindViewById<EditText>(Resource.Id.et_password);

            button_login.Click += delegate
             {
                 user user = new user(un.Text, pw.Text);
                 if (user.CheckInformation())
                 {
                     StartActivity(typeof(MainStart_activity));

                 }
             };



        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
}

