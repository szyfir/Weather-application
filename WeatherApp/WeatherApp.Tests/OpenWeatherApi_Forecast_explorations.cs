using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Web.Script.Serialization;

namespace WeatherApp.Tests
{
    public class OpenWeatherApi_Forecast_explorations
    {
        public string execute(string city)
        {
            return new RowCommunicaion().Forecast_exploration(city);
        }
        [Fact]
        public void returns_response()
        {
            string results = execute("Gdansk");
            Assert.NotEmpty(results);
        }
        [Fact]
        public void returns_json_response()
        {
            string results = execute("Gdansk");

            var json = Record.Exception(() => json_deserialize(results));
            Assert.Null(json);

        }
        [Fact]
        public void returns_GdanskForecast()
        {
            string results = execute("Gdansk");
            var deserialize_object = json_deserialize(results);
            Assert.Equal(40, deserialize_object["cnt"]);
            Assert.Equal("200", deserialize_object["cod"]);
            dynamic[] search_results = deserialize_object["list"];
            Assert.True(search_results.Length > 1);

            
        }

        private static dynamic json_deserialize(string results)
        {
            return new JavaScriptSerializer().Deserialize<dynamic>(results);
        }
    }
}
