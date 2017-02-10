using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace UnitConverter
{
    [Activity(Label = "UnitConverter", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        /*
         Launch Main Screen and initialize event handlers for each button
        */
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button LengthButton = FindViewById<Button>(Resource.Id.Length);
            Button AreaButton = FindViewById<Button>(Resource.Id.Area);
            Button TemperatureButton = FindViewById<Button>(Resource.Id.Temperature);
            Button TimeButton = FindViewById<Button>(Resource.Id.Time);
            Button VolumeButton = FindViewById<Button>(Resource.Id.Volume);
            Button WeightButton = FindViewById<Button>(Resource.Id.Weight);
            LengthButton.Click += (object sender, EventArgs e) =>
            {
                var intentLength = new Intent(this, typeof(LengthActivity));
                StartActivity(intentLength);
            };
            AreaButton.Click += (object sender, EventArgs e) =>
            {
                var intentArea = new Intent(this, typeof(AreaActivity));
                StartActivity(intentArea);
            };
            TemperatureButton.Click += (object sender, EventArgs e) =>
            {
                var intentTemperature = new Intent(this, typeof(TemperatureActivity));
                StartActivity(intentTemperature);
            };
            TimeButton.Click += (object sender, EventArgs e) =>
            {
                var intentTime= new Intent(this, typeof(TimeActivity));
                StartActivity(intentTime);
            };
            VolumeButton.Click += (object sender, EventArgs e) =>
            {
                var intentVolume = new Intent(this, typeof(VolumeActivity));
                StartActivity(intentVolume);
            };
            WeightButton.Click += (object sender, EventArgs e) =>
            {
                var intentWeight = new Intent(this, typeof(WeightActivity));
                StartActivity(intentWeight);
            };

        }
    }
}

