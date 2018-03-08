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

using System.Drawing;

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
      
            GetWeather("Gdańsk");
            GetForecast("Gdańsk");
        }
        public void GetWeather(string city)
        {

            try
            {
                WebClient client = new WebClient();
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID=42c1d2a0b9b958f4fbb51e0edc9896a0", city); //json format (weather info api)
                var json = client.DownloadString(url);

                var results = JsonConvert.DeserializeObject<WeatherInfo.RootObject>(json);
                WeatherInfo.RootObject Output = results;
                //wyswietlanie informacji
                lActualTemp.Content = string.Format("{0:N1} \u00B0" + "C", Output.main.temp - 273.15);    //przeliczenie temp
                lLocation.Content = city.ToUpper();
                image1.Source = SetIcon(Output.weather[0].icon);
                lActualPressure.Content = string.Format("{0} hPa", Output.main.pressure);
                lActualHumidity.Content = string.Format("{0} %", Output.main.humidity);
               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        public void GetForecast(string city)
        {
            try
            {
                WebClient client = new WebClient();
                string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&APPID=42c1d2a0b9b958f4fbb51e0edc9896a0", city);
                var json = client.DownloadString(url);

                var results = JsonConvert.DeserializeObject<Forecast.RootObject>(json);
                Forecast.RootObject Output = results;
                //Co.Text = string.Format("{0:N1} \u00B0" + "C", Output.list[1].main.temp - 273.15);
                //textBox3.Text = string.Format("{0}", Output.list[1].dt_txt);
                lData1.Content = string.Format(" {0}", Output.list[2].dt_txt);
                lTemperature1.Content= string.Format("{0:N1} \u00B0" + "C", Output.list[2].main.temp -273.15);
                lPressure1.Content = string.Format("{0} hPa", Output.list[2].main.pressure);
                lHumidity1.Content = string.Format("{0} %", Output.list[2].main.humidity);
                lVwind.Content = string.Format("{0} m/s", Output.list[2].wind.speed);
                icon1.Source = SetIcon(Output.list[2].weather[0].icon);

            }
            catch (Exception)
            {

            }
        }

        private void tbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = null;

        }





        private void bSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) == false)
            {
                GetWeather(tbSearch.Text.ToString());
                GetForecast(tbSearch.Text.ToString());
            }

        }



        BitmapImage SetIcon(string idIcon)
        {
            string url = string.Format("http://openweathermap.org/img/w/{0}.png",idIcon); // weather icon resource 

            BitmapImage weatherImg = new BitmapImage();
            weatherImg.BeginInit();
            weatherImg.UriSource = new Uri(url);
            weatherImg.EndInit();

            return weatherImg;
        }
    }
}

