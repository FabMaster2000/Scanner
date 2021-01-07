﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
    [Activity(Label = "@string/label_pruefteil_buchen", Theme = "@style/AppTheme")]
    class pruefteil_etikett_drucken_activity : AppCompatActivity
    {
        private AppCompatButton button_pruefteil;
        private AppCompatButton button_aufbau;
        private AppCompatButton button_lagerplatz;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.pruefteil_etikett_drucken);

            button_pruefteil = FindViewById<AppCompatButton>(Resource.Id.button_pruefteil);
            button_aufbau = FindViewById<AppCompatButton>(Resource.Id.button_aufbau);
            button_lagerplatz = FindViewById<AppCompatButton>(Resource.Id.button_lagerplatz);


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