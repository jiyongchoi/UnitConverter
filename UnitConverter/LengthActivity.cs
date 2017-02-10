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
    [Activity(Label = "LengthActivity")]
    public class LengthActivity : Activity
    {
        public string unit_origin = "default";
        public string unit_result = "default";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Length);
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertLength);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueLength);
            Spinner spinnerA = FindViewById<Spinner>(Resource.Id.LengthSpinnerA);
            Spinner spinnerB = FindViewById<Spinner>(Resource.Id.LengthSpinnerB);
            spinnerA.Prompt = "Select unit";
            spinnerA.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(lengthSpinner_ItemSelectedA);
            spinnerB.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(lengthSpinner_ItemSelectedB);
            var lengthAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.LengthSpinnerArray, Android.Resource.Layout.SimpleSpinnerItem);
            lengthAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerA.Adapter = lengthAdapter;
            spinnerB.Adapter = lengthAdapter;
            valueToConvert.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                if (!(String.Equals(unit_origin, "--Choose a Unit--", StringComparison.Ordinal) ||
                String.Equals(unit_result, "--Choose a Unit--", StringComparison.Ordinal) ||
                String.Equals(unit_origin, "default", StringComparison.Ordinal) ||
                String.Equals(unit_result, "default", StringComparison.Ordinal))
                && !string.IsNullOrEmpty(valueToConvert.Text))
                {
                    convertedValue.Text = LengthConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
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
        private void lengthSpinner_ItemSelectedA(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertLength);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueLength);
            string chosenunit = (string)spinner.GetItemAtPosition(e.Position);
            string choose = "--Choose a Unit--";
            if (String.Equals(chosenunit, choose, StringComparison.Ordinal))
            {
                unit_origin = "default";
            }
            else
            {
                unit_origin = chosenunit;
                if (!(String.Equals(unit_result, "default", StringComparison.Ordinal)) && !string.IsNullOrEmpty(valueToConvert.Text))
                {
                    convertedValue.Text = LengthConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
                }
            }
            
        }

        /*
      Event handler for the spinner of result unit 
      */
        private void lengthSpinner_ItemSelectedB(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertLength);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueLength);
            string chosenunit = (string)spinner.GetItemAtPosition(e.Position);
            string choose = "--Choose a Unit--";
            if (String.Equals(chosenunit, choose, StringComparison.Ordinal))
            {
                unit_result = "default";
            }
            else
            {
                unit_result = chosenunit;
                if (!(String.Equals(unit_origin, "default", StringComparison.Ordinal)) && !string.IsNullOrEmpty(valueToConvert.Text))
                {
                    convertedValue.Text = LengthConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
                }
            }


        }

    }
    }
