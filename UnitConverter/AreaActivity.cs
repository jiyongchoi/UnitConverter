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
    public class AreaActivity : Activity
    {
        public string unit_origin = "default";
        public string unit_result = "default";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Area);
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertArea);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueArea);
            Spinner spinnerA = FindViewById<Spinner>(Resource.Id.AreaSpinnerA);
            Spinner spinnerB = FindViewById<Spinner>(Resource.Id.AreaSpinnerB);
            spinnerA.Prompt = "Select unit";
            spinnerA.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(areaSpinner_ItemSelectedA);
            spinnerB.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(areaSpinner_ItemSelectedB);
            var areaAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.AreaSpinnerArray, Android.Resource.Layout.SimpleSpinnerItem);
            areaAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerA.Adapter = areaAdapter;
            spinnerB.Adapter = areaAdapter;
            valueToConvert.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {

                if (!(String.Equals(unit_origin, "--Choose a Unit--", StringComparison.Ordinal) || 
                String.Equals(unit_result, "--Choose a Unit--", StringComparison.Ordinal) ||
                String.Equals(unit_origin, "default", StringComparison.Ordinal) ||
                String.Equals(unit_result, "default", StringComparison.Ordinal)) 
                && !string.IsNullOrEmpty(valueToConvert.Text))
                {
                   convertedValue.Text = AreaConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
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
        private void areaSpinner_ItemSelectedA(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertArea);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueArea);
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
                    convertedValue.Text = AreaConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
                }
            }

        }

        /*
       Event handler for the spinner of result unit 
       */
        private void areaSpinner_ItemSelectedB(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            EditText valueToConvert = FindViewById<EditText>(Resource.Id.ValueToConvertArea);
            TextView convertedValue = FindViewById<TextView>(Resource.Id.convertedValueArea);
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
                    convertedValue.Text = AreaConvert.Convert(unit_origin, unit_result, Convert.ToDouble(valueToConvert.Text)).ToString();
                }
            }
        }
    }
}
