using System.Text;
using System;
namespace UnitConverter
{
    public static class WeightConvert
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

            if (String.Equals(originunit, "Kilogram", StringComparison.Ordinal))
            {
                return kgResult(resultunit, originvalue);
            }
            else if (String.Equals(originunit, "Gram", StringComparison.Ordinal))
            {
                return kgResult(resultunit, originvalue/1000); // convert to kg first
            }
            else if (String.Equals(originunit, "Milligram", StringComparison.Ordinal))
            {
                return kgResult(resultunit, originvalue/1000000); // convert to kg first
            }
            else if (String.Equals(originunit, "Pound", StringComparison.Ordinal))
            {
                return kgResult(resultunit, originvalue / 2.2046226218); // convert to kg first
            }
            else if (String.Equals(originunit, "Ounce", StringComparison.Ordinal))
            {
                return kgResult(resultunit, originvalue / 35.2739619); // convert to kg first
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a weight unit", originunit);
            }
        }

        /// <summary>Return a kg originvalue to that of resultunit
        /// <para>originvalue: the double kg to be converted; 
        /// resultunit: the unit to covert originvalue to</para>
        /// </summary>
        static double kgResult(string resultunit, double originvalue)
        {
            if (String.Equals(resultunit, "Kilogram", StringComparison.Ordinal))
            {
                return originvalue;
            }
            else if (String.Equals(resultunit, "Gram", StringComparison.Ordinal))
            {
                return originvalue * 1000;
            }
            else if (String.Equals(resultunit, "Milligram", StringComparison.Ordinal))
            {
                return originvalue * 1000000;
            }
            else if (String.Equals(resultunit, "Millimetre", StringComparison.Ordinal))
            {
                return originvalue * 1000;
            }
            else if (String.Equals(resultunit, "Pound", StringComparison.Ordinal))
            {
                return originvalue * 2.2046226218;
            }
            else if (String.Equals(resultunit, "Ounce", StringComparison.Ordinal))
            {
                return originvalue * 35.2739619;
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a weight unit", resultunit);
            }
        }
    }
}