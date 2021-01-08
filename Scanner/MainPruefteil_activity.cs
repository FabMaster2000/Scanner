using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Scanner
{
    [Activity(Label = "@string/label_pruefteil", Theme = "@style/AppTheme")]
    public class MainPruefteil_activity : AppCompatActivity
    {
        private Button button_buchen;
        private Button button_info;
        private Button button_etikett_drucken;
        private Button button_dokumentieren;
        private Button button_pruefteil;
        private Button button_aufbau;
        private Button button_lagerplatz;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.pruefteil);

            //Elemts get their ID
            button_buchen = FindViewById<Button>(Resource.Id.button_buchen);
            button_info = FindViewById<Button>(Resource.Id.button_info);
            button_etikett_drucken= FindViewById<Button>(Resource.Id.button_etikett_drucken);
            button_dokumentieren = FindViewById<Button>(Resource.Id.button_dokumentieren);
            button_pruefteil = FindViewById<Button>(Resource.Id.button_pruefteil);
            button_aufbau = FindViewById<Button>(Resource.Id.button_aufbau);
            button_lagerplatz = FindViewById<Button>(Resource.Id.button_lagerplatz);


            //Click-Event
            button_buchen.Click += delegate
            {
                buchen_click();
            };
            button_info.Click += delegate
            {
                info_click();
            };
            button_etikett_drucken.Click += delegate
            {
                etikett_drucken_click();
            };
            button_dokumentieren.Click += delegate
            {
                dokumentieren_click();
            };


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


        //Methods to outsource
        public void buchen_click()
        {
            StartActivity(typeof(pruefteil_buchen_activity));
        }
        public void info_click()
        {
            StartActivity(typeof(pruefteil_info_activity));
        }
        public void etikett_drucken_click()
        {
            StartActivity(typeof(pruefteil_etikett_drucken_activity));
        }
        public void dokumentieren_click()
        {
            StartActivity(typeof(pruefteil_dokumentieren_activity));
        }
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
    }

}