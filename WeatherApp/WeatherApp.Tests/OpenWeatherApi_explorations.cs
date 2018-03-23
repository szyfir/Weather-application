﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Xunit;

namespace WeatherApp.Tests
{
    public class OpenWeatherApi_explorations
    {
        public string execute(string city)
        {
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID=42c1d2a0b9b958f4fbb51e0edc9896a0", city);
            return new HttpClient().GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        [Fact]
        public void returns_response() //sprawdzenie czy cos kryje sie pod url
        {
            var results = execute("Gdansk");
            Assert.NotEmpty(results);
        }
        [Fact]
        public void returns_json_response() //rezultatem jest json = proba deserializacji, srawdzenie czy nie wyrzuca wyjątku 
        {
            var results = execute("Gdansk");
            var json = Record.Exception(() => json_deserialize(results));
            Assert.Null(json);
        }

        private static dynamic json_deserialize(string results)
        {
            return new JavaScriptSerializer().Deserialize<dynamic>(results);
        }

        [Fact]
        public void returns_GdanskUniqueProp_from_other_properties()
        {
            var results = execute("Gdansk");
            dynamic deserialize_object = json_deserialize(results);           
            Assert.Equal("Gdansk", deserialize_object["name"]);
            Assert.Equal(3099434, deserialize_object["id"]);
            Assert.Equal(200, deserialize_object["cod"]);
            Assert.NotEmpty(deserialize_object["weather"]);

        }
        

    }
}
