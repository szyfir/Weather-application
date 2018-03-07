using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetWeather();
            GetForecast();
        }
        public void GetWeather()
        {
            WebClient client = new WebClient();
            string url = @"http://api.openweathermap.org/data/2.5/weather?q=Gdansk&APPID=42c1d2a0b9b958f4fbb51e0edc9896a0"; //json format (weather info api)
            var json = client.DownloadString(url);

            var results = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
            WeatherInfo.root Output = results;
            //wyswietlanie informacji
            textBox1.Text = string.Format("{0} \u00B0" + "C", Output.main.temp - 273.15);    //przeliczenie temp



        }
        public void GetForecast()
        {
            WebClient client = new WebClient();
            string url = @"http://api.openweathermap.org/data/2.5/forecast?q=Gdansk&APPID=42c1d2a0b9b958f4fbb51e0edc9896a0";
            var json = client.DownloadString(url);

            var results = JsonConvert.DeserializeObject<Forecast.RootObject>(json);
            Forecast.RootObject Output = results;
            textBox2.Text = string.Format("{0:N1} \u00B0" + "C", Output.list[1].main.temp - 273.15);
            textBox3.Text = string.Format("{0}", Output.list[1].dt_txt);

        }
    }
}
