using System;
using System.Collections;
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
using Object = Java.Lang.Object;

namespace DSED06Hangman
{
    [Activity(Label = "Hangman", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HangmanActivity : Activity
    {
        private TextView txtName;
        private string name;
        private Button btnHome;
        private int count = 0;
        private TextView Word;
        private TextView WordToGuess;
        private ImageView HangmanImage;
        private LinearLayout Keyboard;
        private LinearLayout Status;
        private TextView GameStatus;

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
            AlphabetButtons();
            LoadWords();


            //Words();
        }

        private void LoadWords()
        {
            //need to tie the asset manager to these assets in this project. This method can only run under the activity as it doesn't know what Assets is otherwise, this.Assets doesn't work
            try
            {
                // Hardcoded for testing purposes. To be commented out later.
                var word = "awkward".ToUpper();

                char[] WordArray = new char[word.Length];
                //int WordArrayLength = WordArray.Length;

                WordArray = word.ToArray();
                Words.Word = WordArray;


                var underscore = "_";
                char[] WordGuessArray;
                string WordGuess = null;
                foreach (char letter in Words.Word)
                {
                    WordGuess += "_";
                }

                WordGuessArray = WordGuess.ToArray();
                Words.WordGuess = WordGuessArray;

                Wordtoguess();
            }
            catch (Exception e)
            {
                Toast.MakeText(this, "Database didn't load\n " + e, ToastLength.Short).Show();
            }
        }

        private void AlphabetButtons()
        {
            btnA = FindViewById<Button>(Resource.Id.btnA);
            btnB = FindViewById<Button>(Resource.Id.btnB);
            btnC = FindViewById<Button>(Resource.Id.btnC);
            btnD = FindViewById<Button>(Resource.Id.btnD);
            btnE = FindViewById<Button>(Resource.Id.btnE);
            btnF = FindViewById<Button>(Resource.Id.btnF);
            btnG = FindViewById<Button>(Resource.Id.btnG);
            btnH = FindViewById<Button>(Resource.Id.btnH);
            btnI = FindViewById<Button>(Resource.Id.btnI);
            btnJ = FindViewById<Button>(Resource.Id.btnJ);
            btnK = FindViewById<Button>(Resource.Id.btnK);
            btnL = FindViewById<Button>(Resource.Id.btnL);
            btnM = FindViewById<Button>(Resource.Id.btnM);
            btnN = FindViewById<Button>(Resource.Id.btnN);
            btnO = FindViewById<Button>(Resource.Id.btnO);
            btnP = FindViewById<Button>(Resource.Id.btnP);
            btnQ = FindViewById<Button>(Resource.Id.btnQ);
            btnR = FindViewById<Button>(Resource.Id.btnR);
            btnS = FindViewById<Button>(Resource.Id.btnS);
            btnT = FindViewById<Button>(Resource.Id.btnT);
            btnU = FindViewById<Button>(Resource.Id.btnU);
            btnV = FindViewById<Button>(Resource.Id.btnV);
            btnW = FindViewById<Button>(Resource.Id.btnW);
            btnX = FindViewById<Button>(Resource.Id.btnX);
            btnY = FindViewById<Button>(Resource.Id.btnY);
            btnZ = FindViewById<Button>(Resource.Id.btnZ);

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

        private void ButtonClick(object sender, EventArgs e)
        {
            //make a fake button
            Button fakeBtn = (Button)sender;

            if (fakeBtn.Clickable)
            {
                string word = new string(Words.Word);

                for (int i = 0; i < Words.Word.Length; i++)
                {
                    var letter = Words.Word[i];

                    if (word.Contains(letter))
                    {
                        //finds if letter clicked is anywhere in the word

                        if (letter.ToString() == fakeBtn.Tag.ToString())
                        {
                            Words.WordGuess[i] = (char)letter;
                        }
                    }


                }
                if (word.Contains(fakeBtn.Tag.ToString()) != true)
                {
                    Words.HangmanLevel++;
                    Toast.MakeText(this, "The letter " + fakeBtn.Tag + " is not in the Word.\nHangman Stage: " + Words.HangmanLevel, ToastLength.Long).Show();

                    //Switch Statement to change image
                    HangmanImage = FindViewById<ImageView>(Resource.Id.ivHangmanStage);
                    if (Words.HangmanLevel == 1)
                    {
                        //txtName = FindViewById<TextView>(Resource.Id.lblName);

                        HangmanImage.SetImageResource(Resource.Drawable.stage1);
                    }
                    if (Words.HangmanLevel == 2)
                    {
                        //txtName = FindViewById<TextView>(Resource.Id.lblName);

                        HangmanImage.SetImageResource(Resource.Drawable.stage2);
                    }
                    if (Words.HangmanLevel == 3)
                    {
                        //txtName = FindViewById<TextView>(Resource.Id.lblName);

                        HangmanImage.SetImageResource(Resource.Drawable.stage3);
                    }
                    if (Words.HangmanLevel == 4)
                    {
                        //txtName = FindViewById<TextView>(Resource.Id.lblName);

                        HangmanImage.SetImageResource(Resource.Drawable.stage4);
                    }
                    if (Words.HangmanLevel == 5)
                    {
                        //txtName = FindViewById<TextView>(Resource.Id.lblName);

                        HangmanImage.SetImageResource(Resource.Drawable.stage5);
                    }
                    if (Words.HangmanLevel == 6)
                    {
                        //txtName = FindViewById<TextView>(Resource.Id.lblName);

                        HangmanImage.SetImageResource(Resource.Drawable.stage6);
                        Keyboard = FindViewById<LinearLayout>(Resource.Id.keyboard);
                        Keyboard.Visibility = ViewStates.Gone;

                        Status = FindViewById<LinearLayout>(Resource.Id.gameStatus);
                        GameStatus = FindViewById<TextView>(Resource.Id.txtStatus);
                        GameStatus.Text = "Game Over!!!";
                        Status.Visibility = ViewStates.Visible;
                    }
                }
                Wordtoguess();
                string wordGuess = new string(Words.WordGuess);
                if (wordGuess.Contains("_") != true)
                {
                    //HangmanImage.SetImageResource(Resource.Drawable.stage6);
                    Keyboard = FindViewById<LinearLayout>(Resource.Id.keyboard);
                    Keyboard.Visibility = ViewStates.Gone;

                    Status = FindViewById<LinearLayout>(Resource.Id.gameStatus);
                    GameStatus = FindViewById<TextView>(Resource.Id.txtStatus);
                    GameStatus.Text = "You Win!!!";
                    Status.Visibility = ViewStates.Visible;
                }

                fakeBtn.Enabled = false;
            }

        }

        private void Wordtoguess()
        {
            WordToGuess = FindViewById<TextView>(Resource.Id.lblHangmanWordToGuess);
            WordToGuess.Text = new string(Words.WordGuess);
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