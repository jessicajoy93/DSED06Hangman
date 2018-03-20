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
    [Activity(Label = "Hangman", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ScoreActivity : Activity
    {
        private Button BackToGame;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GameScore);

            BackToGame = FindViewById<Button>(Resource.Id.btnReturnToGame);
            BackToGame.Click += OnBackToGame_Click;
        }

        private void OnBackToGame_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HangmanActivity));
            this.Finish();
        }
    }
}