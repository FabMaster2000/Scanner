using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.App;
using Android.OS;

namespace Scanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]


    /*
    class User
    {
        private string username;
        private string password;
        private User user;
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
    */


    public class users_hinzufuegen_activity : AppCompatActivity
    {

        private Button button_add_user;
        private Button button_get_password;
        private Button button_all_users;
        private EditText editText_username;
        private EditText editText_password;
        private string username;
        private string password;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set the view
            SetContentView(Resource.Layout.user_hinzufuegen);


            button_add_user = FindViewById<Button>(Resource.Id.button_add_user);
            button_get_password = FindViewById<Button>(Resource.Id.button_get_password);
            button_all_users = FindViewById<Button>(Resource.Id.button_all_users);
            editText_username = FindViewById<EditText>(Resource.Id.editText_username);
            editText_password = FindViewById<EditText>(Resource.Id.editText_password);


            //Click-Events added
            button_add_user.Click += delegate
            {
                add_user_click();
            };

            button_get_password.Click += delegate
            {
                //Edit Text to String
                username = FindViewById<EditText>(Resource.Id.editText_username).Text;
                if (username != "")
                {
                    if (users_information.GetUserPassword(username) != "")
                    {
                        string toast = string.Format("The {0}'s password is: {1}", username, users_information.GetUserPassword(username));
                        Toast.MakeText(this, toast, ToastLength.Long).Show();
                    }
                    else
                    {
                        string toast = string.Format("The username is not created");
                        Toast.MakeText(this, toast, ToastLength.Long).Show();
                    }
                }
                else
                {
                    string toast = string.Format("Please enter a Username");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                }
            };

            //If EditText = username && Enter is pressed
            
            {
                if (e.KeyCode == Keycode.Enter)
                {
                    editText_password.RequestFocus();
                }
            };

            //If EditText = password && Enter is pressed
            editText_password.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                if (e.KeyCode == Keycode.Enter)
                {
                    add_user_click();
                }
            };


            button_all_users.Click += delegate
            {
                PrintUsers();
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }

        public void PrintUsers()
        {
            if (users_information.GetUsers().Count == 0)
            {
                string toast = string.Format("No users registered");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
            else
            {
                foreach (var kvp in users_information.GetUsers())
                {
                    string toast = string.Format("{0} / {1}", kvp.Key, kvp.Value);
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                }
            }
        }

        public void add_user_click()
        {
            //Edit Text to String
            username = FindViewById<EditText>(Resource.Id.editText_username).Text;
            password = FindViewById<EditText>(Resource.Id.editText_password).Text;
            if (password != "")
            {
                users_information.AddUser(username, password);
                string toast = string.Format("{0} added", username);
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                base.OnBackPressed();
            }
            else
            {
                string toast = string.Format("The password could not be empty");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }

        }
    }
}