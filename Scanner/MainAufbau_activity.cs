using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.App;

namespace Scanner
{
    [Activity(Label = "@string/label_aufbau", Theme = "@style/AppTheme")]
    public class MainAufbau_activity : AppCompatActivity
    {
        private Button button_pruefteil;
        private Button button_aufbau;
        private Button button_lagerplatz;
        private Button button_aufbau_kommisionieren;
        private Button button_aufbau_deaktivieren;
        private Button button_aufbau_aktivieren;
        private Button button_aufbau_info;
        private Button button_aufbau_buchen;
        private Button button_aufbau_dokumentieren;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.aufbau);

            //Elements get their ID
            button_pruefteil = FindViewById<Button>(Resource.Id.button_pruefteil);
            button_aufbau = FindViewById<Button>(Resource.Id.button_aufbau);
            button_lagerplatz = FindViewById<Button>(Resource.Id.button_lagerplatz);
            button_aufbau_kommisionieren = FindViewById<Button>(Resource.Id.button_aufbau_kommisionieren);
            button_aufbau_deaktivieren = FindViewById<Button>(Resource.Id.button_aufbau_deaktivieren);
            button_aufbau_aktivieren = FindViewById<Button>(Resource.Id.button_aufbau_aktivieren);
            button_aufbau_info = FindViewById<Button>(Resource.Id.button_aufbau_info);
            button_aufbau_buchen = FindViewById<Button>(Resource.Id.button_aufbau_buchen);
            button_aufbau_dokumentieren = FindViewById<Button>(Resource.Id.button_aufbau_dokumentieren);


            //Click-Event
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

            button_aufbau_kommisionieren.Click += delegate
            {
                aufbau_kommisionieren_click();
            };

            button_aufbau_deaktivieren.Click += delegate
            {
                aufbau_deaktivieren_click();
            };

            button_aufbau_aktivieren.Click += delegate
            {
                aufbau_aktivieren_click();
            };
            button_aufbau_info.Click += delegate
            {
                aufbau_info_click();
            };
            button_aufbau_buchen.Click += delegate
            {
                aufbau_buchen_click();
            };
            button_aufbau_dokumentieren.Click += delegate
            {
                aufbau_dokumentieren_click();
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
        public void aufbau_kommisionieren_click()
        {
            StartActivity(typeof(aufbau_kommisionieren_activity));
        }

        public void aufbau_deaktivieren_click()
        {
            StartActivity(typeof(aufbau_deaktivieren_activity));
        }

        public void aufbau_aktivieren_click()
        {
            StartActivity(typeof(aufbau_aktivieren_activity));
        }

        public void aufbau_info_click()
        {
            StartActivity(typeof(aufbau_info_activity));
        }

        public void aufbau_buchen_click()
        {
            StartActivity(typeof(aufbau_buchen_activity));
        }

        public void aufbau_dokumentieren_click()
        {
            StartActivity(typeof(aufbau_dokumentieren_activity));
        }
    }
}