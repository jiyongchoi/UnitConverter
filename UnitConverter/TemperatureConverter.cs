using System.Text;
using System;
namespace UnitConverter
{
    public static class TemperatureConvert
    {
        /// <summary>Return the desired originvalue by converting it from that of originunit to the new unit resultunit
        /// <para>originvalue: double number to be converted; originunit: the original unit of originvalue
        /// resultunit: the unit to covert originvalue to</para>
        /// </summary>
        public static double Convert(string originunit, string resultunit, double originvalue)
        {
            if (String.Equals(originunit, resultunit, StringComparison.Ordinal))
            {
                return originvalue;
            }

            if (String.Equals(originunit, "Celcius", StringComparison.Ordinal))
            {
                return celResult(resultunit, originvalue); 
            }
            else if (String.Equals(originunit, "Kelvin", StringComparison.Ordinal))
            {
                return celResult(resultunit, originvalue - 273.15); // convert to celcius first
            }
            else if (String.Equals(originunit, "Farenheit", StringComparison.Ordinal))
            {
                return celResult(resultunit, (originvalue - 32) * 5 / 9); // convert to celcius first
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a temperature unit", "original");
            }
        }

        // <summary>Return a celcius originvalue to that of resultunit
        /// <para>originvalue: the double celcius to be converted; 
        /// resultunit: the unit to covert originvalue to</para>
        /// </summary>
        static double celResult(string resultunit, double originvalue)
        {
            if (String.Equals(resultunit, "Celcius", StringComparison.Ordinal))
            {
                return originvalue;
            }
            else if (String.Equals(resultunit, "Kelvin", StringComparison.Ordinal))
            {
                return originvalue + 273.15;
            }
            else if (String.Equals(resultunit, "Farenheit", StringComparison.Ordinal))
            {
                return (originvalue * 9 / 5) + 32;
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a temperature unit", "original");
            }
        }
    }
}