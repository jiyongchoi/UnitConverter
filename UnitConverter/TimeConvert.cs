using System.Text;
using System;
namespace UnitConverter
{
    public static class TimeConvert
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
            if (String.Equals(originunit, "Second", StringComparison.Ordinal))
            {
                return secondResult(resultunit, originvalue);
            }
            else if (String.Equals(originunit, "Millisecond", StringComparison.Ordinal))
            {
                return secondResult(resultunit, originvalue / 1000); // convert to seconds first 
            }
            else if (String.Equals(originunit, "Minute", StringComparison.Ordinal))
            {
                return secondResult(resultunit, originvalue * 60); // convert to seconds first 
            }
            else if (String.Equals(originunit, "Hour", StringComparison.Ordinal))
            {
                return secondResult(resultunit, originvalue * 360); // convert to seconds first 
            }
            else if (String.Equals(originunit, "Hour", StringComparison.Ordinal))
            {
                return secondResult(resultunit, originvalue * (360*24)); // convert to seconds first 
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a time unit", originunit);
            }
        }

        /// <summary>Return a second originvalue to that of resultunit
        /// <para>originvalue: the double second to be converted; 
        /// resultunit: the unit to covert originvalue to</para>
        /// </summary>
        static double secondResult(string resultunit, double originvalue)
        {
            if (String.Equals(resultunit, "Second", StringComparison.Ordinal))
            {
                return originvalue;
            }
            else if (String.Equals(resultunit, "Millisecond", StringComparison.Ordinal))
            {
                return originvalue * 1000;
            }
            else if (String.Equals(resultunit, "Minute", StringComparison.Ordinal))
            {
                return originvalue / 60;
            }
            else if (String.Equals(resultunit, "Hour", StringComparison.Ordinal))
            {
                return originvalue / 360;
            }
            else if (String.Equals(resultunit, "Day", StringComparison.Ordinal))
            {
                return originvalue / (360 * 24);
            }
            else
            {
                throw new System.ArgumentException("Parameter must be a time unit", resultunit);
            }
        }
    }
}