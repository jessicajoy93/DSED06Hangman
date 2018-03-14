using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DSED06Hangman
{
    static class Words
    {
        public static string Word { get; set; }
        public static string WordGuess { get; set; }
        public static int Score { get; set; }
    }
}