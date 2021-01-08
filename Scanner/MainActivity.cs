using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Util;
using System.Linq;

namespace Scanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button button_login;
        private Button button_hinzufuegen;
        private EditText editText_username;
        private EditText editText_password;
        private string username;
        private string password;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);



            // Set the view
            SetContentView(Resource.Layout.login);

            //Element get their ID
            button_login = FindViewById<Button>(Resource.Id.button_login);
            button_hinzufuegen = FindViewById<Button>(Resource.Id.button_hinzufuegen);
            editText_username = FindViewById<EditText>(Resource.Id.editText_username);
            editText_password = FindViewById<EditText>(Resource.Id.editText_password);

            //Start Dictionary
            users_information.StartDictionaray();



            //If Login-Button is clicked
            button_login.Click += delegate
            {
                //EditText to String
                username = FindViewById<EditText>(Resource.Id.editText_username).Text;
                password = FindViewById<EditText>(Resource.Id.editText_password).Text;

                if (users_information.CheckInformation(username, password))
                {

                    //Edit Text to String
                    username = FindViewById<EditText>(Resource.Id.editText_username).Text;
                    password = FindViewById<EditText>(Resource.Id.editText_password).Text;

                    StartActivity(typeof(MainHome_activity));

                }
                else
                {
                    //Show PopUp Window
                    string toast = string.Format("Wrong Login-Informations");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                }
            };



            //If Hinzufuegen-Button is clicked
            button_hinzufuegen.Click += delegate
            {
                //EditText to String
                username = FindViewById<EditText>(Resource.Id.editText_username).Text;
                password = FindViewById<EditText>(Resource.Id.editText_password).Text;

                if (password.Length != 0)
                {
                    if (password == "root")
                    {
                        StartActivity(typeof(users_hinzufuegen_activity));
                    }

                    //Wrong password
                    else
                    {
                        //Show PopUp Window
                        string toast = string.Format("Wrong Password");
                        Toast.MakeText(this, toast, ToastLength.Long).Show();
                    }
                }

                //No password
                else
                {
                    //Show PopUp Window
                    string toast = string.Format("Password required");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();

                };

            };



        }


       public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
}

