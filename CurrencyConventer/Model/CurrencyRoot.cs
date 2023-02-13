using System;
using System.Collections.Generic;

namespace CurrencyConventer.Model
{
    internal class CurrencyRoot
    {
        public Dictionary<string,double> Rates { get; set; }
        public long TimeStamp { get; set; }



        public double Calc(double fromRate,double toRate,double value)
        {
            return Math.Round((value / fromRate) * toRate,2);
        }
    }
}
