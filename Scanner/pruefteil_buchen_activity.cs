using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;

namespace Scanner
{
    [Activity(Label = "@string/label_pruefteil_buchen", Theme = "@style/AppTheme")]
    class pruefteil_buchen_activity : AppCompatActivity
    {

        private Button button_pruefteil;
        private Button button_aufbau;
        private Button button_lagerplatz;
        private Spinner spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.pruefteil_buchen);
            

            //Elemts get their ID
            button_pruefteil = FindViewById<Button>(Resource.Id.button_pruefteil);
            button_aufbau = FindViewById<Button>(Resource.Id.button_aufbau);
            button_lagerplatz = FindViewById<Button>(Resource.Id.button_lagerplatz);
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            
            //Add Spinner-Event
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            
            //Creat Spinner
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.Lagerorte, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            //Click-Events 
            button_pruefteil.Click += delegate
            {
                    pruefteil_click();
            };

            button_aufbau.Click += delegate
            {
                aufbau_click();
            };

            button_lagerplatz.Click += delegate
            {
                lagerplatz_click();
            };


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            if (spinner.GetItemAtPosition(e.Position) != spinner.GetItemAtPosition(0))
            {
                //Show PopUp Window
                string toast = string.Format("{0} gewählt", spinner.GetItemAtPosition(e.Position));
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
        }


        //Methods to outsource
        public void pruefteil_click()
        {
            StartActivity(typeof(MainPruefteil_activity));
        }

        public void aufbau_click()
        {
            StartActivity(typeof(MainAufbau_activity));
        }

        public void lagerplatz_click()
        {
            StartActivity(typeof(MainLagerplatz_activity));
        }

        public void click(View v)
        {
            button_aufbau.Text = "Yes";
        }
    }
}