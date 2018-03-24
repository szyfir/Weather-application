using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Tests
{
    public class RowCommunicaion
    {
        public string Weather_exploration(string city)
        {

            return GetHttp("weather",city);
        }


        public string Forecast_exploration(string city)
        {

            return GetHttp("forecast",city);
        }
        private static string GetHttp(string property,string city)
        {

            
            string url = string.Format("http://api.openweathermap.org/data/2.5/{0}?q={1}&APPID=42c1d2a0b9b958f4fbb51e0edc9896a0", property,city);
            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
