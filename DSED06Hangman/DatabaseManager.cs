using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace DSED06Hangman
{
    class DatabaseManager
    {
        //https://components.xamarin.com/gettingstarted/sqlite-net 
        //https://github.com/praeclarum/sqlite-net
        //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/

        //https://github.com/praeclarum/sqlite-net/blob/master/src/SQLite.cs


        //YOUR CLASS NAME MUST BE YOUR TABLE NAME
        private string tag = "aaaaa";
        SQLiteConnection db;

        public DatabaseManager()
        {
            DBConnect();
        }

        private void DBConnect()
        {
            db = new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Scores.db"));
        }

        public void AddItem()
        {
            Log.Info(tag, "AddTem Name = " + Words.Name + " AddItem Score = " + Words.Score);
            try
            {
                var AddThis = new scoring
                {
                    Name = Words.Name,
                    Score = Words.Score
                };
                db.Insert(AddThis);

                Log.Info(tag)
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}