using System;
using System.Collections.Generic;
using System.IO;
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
    [Activity(Label = "Hangman")]
    public class HangmanActivity : Activity
    {
        private TextView txtName;
        private string name;
        private Button btnHome;
        private int count = 0;
        List<string> HangmanWordList = new List<string>();
        private TextView Word;

        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
        private Button btnE;
        private Button btnF;
        private Button btnG;
        private Button btnH;
        private Button btnI;
        private Button btnJ;
        private Button btnK;
        private Button btnL;
        private Button btnM;
        private Button btnN;
        private Button btnO;
        private Button btnP;
        private Button btnQ;
        private Button btnR;
        private Button btnS;
        private Button btnT;
        private Button btnU;
        private Button btnV;
        private Button btnW;
        private Button btnX;
        private Button btnY;
        private Button btnZ;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Hangman);
            name = Intent.GetStringExtra("Name");
            txtName = FindViewById<TextView>(Resource.Id.lblName);
            txtName.Text = name;

            Home();
            //AlphabetButtons();
            LoadWords();
            //Words();
        }

        private void LoadWords()
        {
            //need to tie the asset manager to these assets in this project. This method can only run under the activity as it doesn't know what Assets is otherwise, this.Assets doesn't work
            try
            {
                var word = "awkward";
                Words.Word = word;
                Toast.MakeText(this, Words.Word, ToastLength.Long).Show();
                //var assets = Assets;
                //using (var sr = new StreamReader(assets.Open("words.txt")))
                //{
                //    while (!sr.EndOfStream)
                //    {
                //        var text = sr.ReadLine();
                //        if (text != string.Empty && text.Length > 3) //ignore empty lines or words less than 3 letters
                //        {
                //            text = text.Trim();
                //            var word = text.Remove(text.IndexOf(' '));

                //            //cut the stuff you don't want
                //            if (word.Contains("-"))
                //            {
                //                word = word.Replace("-", "");
                //            }

                //            word = word.Trim();
                //            Toast.MakeText(this, word, ToastLength.Long).Show();
                //        }
                //    }
                //}
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Database didn't load", ToastLength.Short).Show();
            }
        }

        private void AlphabetButtons()
        {
            MainActivity.btnPlay.Click += btnClick;
            btnA.Click += ButtonClick;
            btnB.Click += ButtonClick;
            btnC.Click += ButtonClick;
            btnD.Click += ButtonClick;
            btnE.Click += ButtonClick;
            btnF.Click += ButtonClick;
            btnG.Click += ButtonClick;
            btnH.Click += ButtonClick;
            btnI.Click += ButtonClick;
            btnJ.Click += ButtonClick;
            btnK.Click += ButtonClick;
            btnL.Click += ButtonClick;
            btnM.Click += ButtonClick;
            btnN.Click += ButtonClick;
            btnO.Click += ButtonClick;
            btnP.Click += ButtonClick;
            btnQ.Click += ButtonClick;
            btnR.Click += ButtonClick;
            btnS.Click += ButtonClick;
            btnT.Click += ButtonClick;
            btnU.Click += ButtonClick;
            btnV.Click += ButtonClick;
            btnW.Click += ButtonClick;
            btnX.Click += ButtonClick;
            btnY.Click += ButtonClick;
            btnZ.Click += ButtonClick;
        }

        private void btnClick(object sender, EventArgs e)
        {
            btnA.Enabled = true;
            btnB.Enabled = true;
            btnC.Enabled = true;
            btnD.Enabled = true;
            btnE.Enabled = true;
            btnF.Enabled = true;
            btnG.Enabled = true;
            btnH.Enabled = true;
            btnI.Enabled = true;
            btnJ.Enabled = true;
            btnK.Enabled = true;
            btnL.Enabled = true;
            btnM.Enabled = true;
            btnN.Enabled = true;
            btnO.Enabled = true;
            btnP.Enabled = true;
            btnQ.Enabled = true;
            btnR.Enabled = true;
            btnS.Enabled = true;
            btnT.Enabled = true;
            btnU.Enabled = true;
            btnV.Enabled = true;
            btnW.Enabled = true;
            btnX.Enabled = true;
            btnY.Enabled = true;
            btnZ.Enabled = true;

            GenerateWord();
        }

        private void GenerateWord()
        {
            Random rand = new Random();

            int RndNumber = rand.Next(1, HangmanWordList.Count);

            Words.Word = HangmanWordList[RndNumber];
            Word.Text = Words.Word;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            //make a fake button
            Button btn = (Button)sender;

            //if (btn.Text == Clicked)
            //{

            //}
        }

        private void HangmanWords()
        {
            int lineCount = File.ReadAllLines(@"C:\words.txt").Length;
            Random rnd = new Random();
            int randomLineNum = rnd.Next(lineCount);
            int indicator = 0;

            using (var reader = File.OpenText(@"C:\words.txt"))
            {
                while (reader.ReadLine() != null)
                {
                    if (indicator == randomLineNum)
                    {
                        break;
                    }
                    indicator++;
                    Toast.MakeText(this, "Your random line is " + indicator, ToastLength.Long).Show();
                }
            }
        }

        private void Home()
        {
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnHome.Click += onHome_Click;
        }

        private void onHome_Click(object sender, EventArgs e)
        {
            var homeActivityIntent = new Intent(this, typeof(MainActivity));
            name = "";
            txtName.Text = "";
            StartActivity(homeActivityIntent);
        }
    }
}