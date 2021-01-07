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
    public class user
    {
        private bool x;
        private string Username;
        private string Password;
        private IDictionary<string, string> numberNames = new Dictionary<string, string>()
        {
            {"Hallo", "Hallo"},
            {"Test","Test" },
            {"j","j"}
        };

        public user(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;

        }

        public bool CheckInformation()
        {

            foreach (var kvp in numberNames)
            {
                if (Username == kvp.Key && Password == kvp.Value)
                    x = true;
                else
                    x = false;
            }
            return x;
        }
    }
}