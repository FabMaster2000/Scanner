using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
    class Methode : Activity
    {
        interface IActivityMethode
    {


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

            public bool test()
            {
                return true;
            }
        }
    }
}
