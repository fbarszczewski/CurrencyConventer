using System.Collections.Generic;

namespace CurrencyConventer.Model
{
    internal class CurrencyRoot
    {
        //public Rate Rates { get; set; }
        public Dictionary<string,double> Rates { get; set; }
        public long TimeStamp { get; set; }


        public CurrencyRoot()
        {

        }

       
    }
}
