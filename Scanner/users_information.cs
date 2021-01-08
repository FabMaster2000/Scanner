using System.Collections.Generic;

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
            //foreach Key-Value-Pair, to get all users(Key) with their password(Value)
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
            //foreach Key-Value-Pair, to get all users(Key) with their password(Value)
            foreach (var kvp in users)
            {
                //If-Username is created
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