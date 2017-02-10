using System.Text;
using System;
namespace UnitConverter
{
    public static class LengthConvert
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

            if (String.Equals(originunit, "Metre", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue);
            }
            else if (String.Equals(originunit, "Kilometre", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue * 1000); // convert to metre first
            }
            else if (String.Equals(originunit, "Centimetre", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue / 100); // convert to metre first
            }
            else if (String.Equals(originunit, "Millimetre", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue / 1000); // convert to metre first
            }
            else if (String.Equals(originunit, "Mile", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue * 1609.34); // convert to metre first
            }
            else if (String.Equals(originunit, "Yard", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue * 0.9144); // convert to metre first
            }
            else if (String.Equals(originunit, "Foot", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue * 0.3048); // convert to metre first
            }
            else if (String.Equals(originunit, "Inch", StringComparison.Ordinal))
            {
                return metreResult(resultunit, originvalue * 0.0254); // convert to metre first
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a length unit", "original");
            }
        }

        /// <summary>Return a metre originvalue to that of resultunit
        /// <para>originvalue: the double metre to be converted; 
        /// resultunit: the unit to covert originvalue to</para>
        /// </summary>
        static double metreResult(string resultunit, double originvalue)
        {
            if (String.Equals(resultunit, "Metre", StringComparison.Ordinal))
            {
                return originvalue;
            }
            else if (String.Equals(resultunit, "Kilometre", StringComparison.Ordinal))
            {
                return originvalue / 1000;
            }
            else if (String.Equals(resultunit, "Centimetre", StringComparison.Ordinal))
            {
                return originvalue * 100;
            }
            else if (String.Equals(resultunit, "Millimetre", StringComparison.Ordinal))
            {
                return originvalue * 1000;
            }
            else if (String.Equals(resultunit, "Mile", StringComparison.Ordinal))
            {
                return originvalue / 1609.344;
            }
            else if (String.Equals(resultunit, "Yard", StringComparison.Ordinal))
            {
                return originvalue * 1.0936;
            }
            else if (String.Equals(resultunit, "Foot", StringComparison.Ordinal))
            {
                return originvalue * 3.28084;
            }
            else if (String.Equals(resultunit, "Inch", StringComparison.Ordinal))
            {
                return originvalue * 39.3701;
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a length unit", "original");
            }
        }
    }
}