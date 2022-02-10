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
using Xamarin.Essentials;

namespace HapticFeedback_AppEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",MainLauncher =true)]
    public class MainActivity : Activity
    {
        private Button myClick;
        private Button myLongClick;
        private TextView mytextV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            myClick = FindViewById<Button>(Resource.Id.buttonClick);
            myLongClick = FindViewById<Button>(Resource.Id.buttonLong);
            mytextV = FindViewById<TextView>(Resource.Id.textViewHF1);

            myClick.Click += MyClick_Click;
            myLongClick.Click += MyLongClick_Click;
        }

        private void MyLongClick_Click(object sender, EventArgs e)
        {
            HapticFeedback.Perform(HapticFeedbackType.LongPress);
            mytextV.Text = $"Long Press Performed : {DateTime.UtcNow:t}";
        }

        private void MyClick_Click(object sender, EventArgs e)
        {
            HapticFeedback.Perform(HapticFeedbackType.Click);
            mytextV.Text = $"CLick Performed: {DateTime.UtcNow:t}";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}