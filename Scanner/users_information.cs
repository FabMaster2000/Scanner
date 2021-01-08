using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner
{
    public class users_information
    {
         
        private static string pw;
        private static bool x;
        private static IDictionary<string, string> users = new Dictionary<string, string>();
        
        public static void StartDictionaray()
        {
            users = new Dictionary<string, string>();
        }

        public static IDictionary<string, string> GetUsers()
        {
            return users;
        }

        public static bool CheckInformation(string username, string password)
        {

            foreach (var kvp in users)
            {
                if (username == kvp.Key && password == kvp.Value)
                    x = true;
                else
                    x = false;
            }
            return x;
        }


        public static string GetUserPassword(string key)
        {
            foreach (var kvp in users)
            {
                if(kvp.Key == key)
                {
                    pw =  kvp.Value; 
                }
            }
            return pw;
        }


        public static void AddUser(string username, string password)
        {
            users.Add(username, password);
        }
    }
}