using System.Text;
using System;
namespace UnitConverter
{
    public static class VolumeConvert
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
            if (String.Equals(originunit, "Liter", StringComparison.Ordinal))
            {
                return literResult(resultunit, originvalue);
            }
            else if (String.Equals(originunit, "Milliliter", StringComparison.Ordinal))
            {
                return literResult(resultunit, originvalue / 1000); // convert to liter first 
            }
            else if (String.Equals(originunit, "Gallon", StringComparison.Ordinal))
            {
                return literResult(resultunit, originvalue * 3.78541); // convert to liter first 
            }
            else if (String.Equals(originunit, "Pint", StringComparison.Ordinal))
            {
                return literResult(resultunit, originvalue / 2.11338); // convert to liter first 
            }
            else if (String.Equals(originunit, "Quart", StringComparison.Ordinal))
            {
                return literResult(resultunit, originvalue / 1.05669); // convert to liter first 
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a volume unit", originunit);
            }
        }

        /// <summary>Return a liter originvalue to that of resultunit
        /// <para>originvalue: the double liter to be converted; 
        /// resultunit: the unit to covert originvalue to</para>
        /// </summary>
        static double literResult(string resultunit, double originvalue)
        {
            if (String.Equals(resultunit, "Liter", StringComparison.Ordinal))
            {
                return originvalue;
            }
            else if (String.Equals(resultunit, "Milliliter", StringComparison.Ordinal))
            {
                return originvalue * 1000;
            }
            else if (String.Equals(resultunit, "Gallon", StringComparison.Ordinal))
            {
                return originvalue / 3.78541;
            }
            else if (String.Equals(resultunit, "Pint", StringComparison.Ordinal))
            {
                return originvalue * 2.11338;
            }
            else if (String.Equals(resultunit, "Quart", StringComparison.Ordinal))
            {
                return originvalue * 1.05669;
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a volume unit", resultunit);
            }
        }
    }
}