using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class EjercicioHipoteca
    {
        public static double GetMensualFee(double capital, double yearlyInterest, int termInMonths)
        {
            yearlyInterest /= 12;
            double divisor = 100 * (1 - Math.Pow(1 + (yearlyInterest / 100), - termInMonths));

            if (capital <= 0 || yearlyInterest < 0 || termInMonths <= 0 || divisor <= 0)
                return double.NaN;
            return (capital * yearlyInterest) / divisor;
        }
    }
}
