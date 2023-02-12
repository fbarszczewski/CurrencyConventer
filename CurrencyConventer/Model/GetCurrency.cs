using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyConventer.Model
{
    internal  class GetCurrency
    {
        public CurrencyRoot CurrencyRates { get; set; }

        public GetCurrency()
        {
            CurrencyRates = new CurrencyRoot();
        }

        public static async Task<CurrencyRoot> GetData<T>(string url)
        {
            var newRoot = new CurrencyRoot();

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage responseMessage = await client.GetAsync(url);

                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var responceString = await responseMessage.Content.ReadAsStringAsync();
                        var responceObject = JsonConvert.DeserializeObject<CurrencyRoot>(responceString);

                        //MessageBox.Show("Timestamp: " + responceObject.TimeStamp, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                        return responceObject;
                    }
                    return newRoot;
                }
            }
            catch (Exception)
            {

                return newRoot;
            }
        }

    }
}
