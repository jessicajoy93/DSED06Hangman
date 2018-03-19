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
using Object = Java.Lang.Object;

namespace DSED06Hangman
{
    static class Words
    {
        public static char[] Word { get; set; }
        public static char[] WordGuess { get; set; }
        public static int Score { get; set; } = 0;
        public static int HangmanLevel { get; set; } = 0;
    }
}