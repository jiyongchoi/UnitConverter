using System.Text;
using System;
namespace UnitConverter
{
    public static class TemperatureConvert
    {

        public static double Convert(string originunit, string resultunit, double originvalue)
        {

            if (String.Equals(originunit, "Celcius", StringComparison.Ordinal))
            {
                return celResult(resultunit, originvalue);
            }
            else if (String.Equals(originunit, "Kelvin", StringComparison.Ordinal))
            {
                return celResult(resultunit, originvalue - 273.15);
            }
            else if (String.Equals(originunit, "Farenheit", StringComparison.Ordinal))
            {
                return celResult(resultunit, (originvalue-32)*5/9 );
            }
            else
            {
                return 0; //error for now
            }
        }
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
                return 0;
            }
        }
    }
}