using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace DSED06Hangman
{
    [Activity(Label = "Hangman", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button btnPlay;
        private TextView txtName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            StartUp();
        }

        private void StartUp()
        {
            txtName = FindViewById<TextView>(Resource.Id.etName);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnPlay.Click += onPlay_Click;
        }

        private void onPlay_Click(object sender, EventArgs e)
        {
            //Toast.MakeText(this, "Your name is " + txtName.Text, ToastLength.Long).Show();

            var hangmanActivityIntent = new Intent(this, typeof(HangmanActivity));
            hangmanActivityIntent.PutExtra("Name", txtName.Text);

            StartActivity(hangmanActivityIntent);
        }
    }
}

