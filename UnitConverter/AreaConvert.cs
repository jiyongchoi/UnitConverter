using System.Text;
using System;
namespace UnitConverter
{
    public static class AreaConvert
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
            if (String.Equals(originunit, "Square Metre", StringComparison.Ordinal))
            {
                return sqmResult(resultunit, originvalue);
            }
            else if (String.Equals(originunit, "Hectare", StringComparison.Ordinal))
            {
                return sqmResult(resultunit, originvalue * 10000); // convert to sqm first
            }
            else if (String.Equals(originunit, "Square Foot", StringComparison.Ordinal))
            {
                return sqmResult(resultunit, originvalue / 10.76391041671); // convert to sqm first
            }
            else if (String.Equals(originunit, "Acre", StringComparison.Ordinal))
            {
                return sqmResult(resultunit, originvalue * 4046.86); // convert to sqm first
            }
            else
            {
                throw new System.ArgumentException("Parameter must be an area unit", originunit);
            }
        }

        /// <summary>Return a square metre originvalue to that of resultunit
        /// <para>originvalue: the double square metre to be converted; 
        /// resultunit: the unit to covert originvalue to</para>
        /// </summary>
        static double sqmResult(string resultunit, double originvalue)
        {
            if (String.Equals(resultunit, "Square Metre", StringComparison.Ordinal))
            {
                return originvalue;
            }
            else if (String.Equals(resultunit, "Hectare", StringComparison.Ordinal))
            {
                return originvalue * 0.0001;
            }
            else if (String.Equals(resultunit, "Square Foot", StringComparison.Ordinal))
            {
                return originvalue * 10.76391041671;
            }
            else if (String.Equals(resultunit, "Acre", StringComparison.Ordinal))
            {
                return originvalue / 4046.86;
            }
            else
            {
                throw new System.ArgumentException("Parameter must be an area unit", resultunit);
            }
        }
    }
}