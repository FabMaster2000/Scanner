using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Support.V7.App;
using Android.App;
using Android.OS;
using Android.Views.InputMethods;

namespace Scanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
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
            SetContentView(Resource.Layout.user_hinzufuegen);

            //Elements get their ID
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
                //EditText to String
                username = FindViewById<EditText>(Resource.Id.editText_username).Text;
                if (username != "")
                {
                    if (users_information.GetUserPassword(username) != null)
                    {
                        //PopUp-Window
                        string toast = string.Format("The {0}'s password is: {1}", username, users_information.GetUserPassword(username));
                        Toast.MakeText(this, toast, ToastLength.Long).Show();
                    }
                    else
                    {
                        //PopUp-Window
                        string toast = string.Format("The user is not created");
                        Toast.MakeText(this, toast, ToastLength.Long).Show();
                    }
                }
                else
                {
                    //PopUp-Window
                    string toast = string.Format("Please enter a Username");
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                    //Focus on Username-EditText
                    editText_username.RequestFocus();
                    
                    //Show Keyboard
                    InputMethodManager inputMethodManager = GetSystemService(Context.InputMethodService) as InputMethodManager;
                    inputMethodManager.ShowSoftInput(editText_username, ShowFlags.Forced);
                    inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
                }
            };

            /*If EditText = username && Enter is pressed -> Funktioniert nicht
            editText_username.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                if (e.KeyCode == Keycode.Enter)
                {
                    //Set focus to Password-EditText
                    editText_password.RequestFocus();
                }
            };*/

            /*If EditText = password && Enter is pressed -> Funktioniert nicht
            editText_password.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                if (e.KeyCode == Keycode.Enter)
                {
                    //Hit the add_user Button
                    add_user_click();
                }
            };*/


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

        

        public void add_user_click()
        {
            //Edit Text to String
            username = FindViewById<EditText>(Resource.Id.editText_username).Text;
            password = FindViewById<EditText>(Resource.Id.editText_password).Text;
            
            if (password != "")
            {
                //AddUser
                users_information.AddUser(username, password);
                //Show PopUp Window
                string toast = string.Format("{0} added", username);
                Toast.MakeText(this, toast, ToastLength.Long).Show();
                //Hit the Back-Button
                base.OnBackPressed();
            }
            else
            {
                //Show PopUp Window
                string toast = string.Format("The password could not be empty");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }

        }

        public void PrintUsers()
        {
            if (users_information.GetUsers().Count == 0)
            {
                //Show PopUp Window
                string toast = string.Format("No users registered");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
            else
            {
                //Foreach Key-Value-Par, to get all Users
                foreach (var kvp in users_information.GetUsers())
                {
                    //Show PopUp Window
                    string toast = string.Format("{0} / {1}", kvp.Key, kvp.Value);
                    Toast.MakeText(this, toast, ToastLength.Long).Show();
                }
            }
        }
    }
}