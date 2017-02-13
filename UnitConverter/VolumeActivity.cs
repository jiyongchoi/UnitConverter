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

namespace UnitConverter
{
    [Activity(Label = "TimeActivity")]
    public class VolumeActivity : Activity
    {
        public string unit_origin = "default";
        public string unit_result = "default";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Volume);
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertVolume);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueVolume);
            Spinner spinnerA = FindViewById<Spinner>(Resource.Id.VolumeSpinnerA);
            Spinner spinnerB = FindViewById<Spinner>(Resource.Id.VolumeSpinnerB);
            spinnerA.Prompt = "Select unit";
            spinnerA.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(volumeSpinner_ItemSelectedA);
            spinnerB.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(volumeSpinner_ItemSelectedB);
            var volumeAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.VolumeSpinnerArray, Android.Resource.Layout.SimpleSpinnerItem);
            volumeAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerA.Adapter = volumeAdapter;
            spinnerB.Adapter = volumeAdapter;
            valueToConvert.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                if (!(String.Equals(unit_origin, "--Choose a Unit--", StringComparison.Ordinal) ||
                String.Equals(unit_result, "--Choose a Unit--", StringComparison.Ordinal) ||
                String.Equals(unit_origin, "default", StringComparison.Ordinal) ||
                String.Equals(unit_result, "default", StringComparison.Ordinal))
                && !string.IsNullOrEmpty(valueToConvert.Text))
                {
                    convertedValue.Text = VolumeConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
                }
                if (string.IsNullOrEmpty(valueToConvert.Text))
                {
                    convertedValue.Text = valueToConvert.Text;
                }

            };

        }

        /*
      Event handler for the spinner of original unit 
      */
        private void volumeSpinner_ItemSelectedA(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertVolume);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueVolume);
            string chosenunit = (string)spinner.GetItemAtPosition(e.Position);
            string choose = "--Choose a Unit--";
            if (String.Equals(chosenunit, choose, StringComparison.Ordinal))
            {
                unit_origin = "default";
            }
            else
            {
                unit_origin = chosenunit;
                if (!(String.Equals(unit_result, "default", StringComparison.Ordinal) || string.IsNullOrEmpty(valueToConvert.Text)))
                {
                    convertedValue.Text = VolumeConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
                }
            }

        }

        /*
       Event handler for the spinner of result unit 
       */
        private void volumeSpinner_ItemSelectedB(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertVolume);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueVolume);
            string chosenunit = (string)spinner.GetItemAtPosition(e.Position);
            string choose = "--Choose a Unit--";
            if (String.Equals(chosenunit, choose, StringComparison.Ordinal))
            {
                unit_result = "default";

            }
            else
            {
                unit_result = chosenunit;
                if (!(String.Equals(unit_origin, "default", StringComparison.Ordinal) || string.IsNullOrEmpty(valueToConvert.Text)))
                {
                    convertedValue.Text = VolumeConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
                }
            }
        }

    }
}
