using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Data.SqlClient;
using System;
using Org.Xmlpull.V1.Sax2;

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


            //Check Network Access
            if (!(CheckPermissionGranted(Android.Manifest.Permission.AccessNetworkState) && CheckPermissionGranted(Android.Manifest.Permission.Internet)))
            {
                //Show PopUp Window
                string toast = string.Format("Network Access failed!");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
            else
            {
                //Show PopUp Window
                string toast = string.Format("Network Access sucessful!");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }

           

            /*
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "<your_server>.database.windows.net";
                builder.UserID = "<your_username>";
                builder.Password = "<your_password>";
                builder.InitialCatalog = "<your_database>";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT name, collation_name FROM sys.databases";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
            */

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

        public bool CheckPermissionGranted(string Permission)
        {
            if(CheckSelfPermission(Permission) != Android.Content.PM.Permission.Granted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

