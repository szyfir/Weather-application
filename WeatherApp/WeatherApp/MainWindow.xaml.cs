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
                lActualWind.Content = string.Format("{0} m/s", Output.wind.speed);
                
               
            }

            catch (Exception)
            {
                MessageBox.Show("Błędna nazwa miejscowości");
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

            lData1.Content = string.Format(" {0}", Output.list[5].dt_txt);
            lTemperature1.Content = string.Format("{0:N1} \u00B0" + "C", Output.list[5].main.temp - 273.15);
            lPressure1.Content = string.Format("{0} hPa", Output.list[5].main.pressure);
            lHumidity1.Content = string.Format("{0} %", Output.list[5].main.humidity);
            lVwind.Content = string.Format("{0} m/s", Output.list[5].wind.speed);
            icon1.Source = SetIcon(Output.list[5].weather[0].icon);

            lData2.Content = string.Format(" {0}", Output.list[13].dt_txt);
            lTemperature2.Content = string.Format("{0:N1} \u00B0" + "C", Output.list[13].main.temp - 273.15);
            lPressure2.Content = string.Format("{0} hPa", Output.list[13].main.pressure);
            lHumidity2.Content = string.Format("{0} %", Output.list[13].main.humidity);
            lVwind2.Content = string.Format("{0} m/s", Output.list[13].wind.speed);
            icon2.Source = SetIcon(Output.list[13].weather[0].icon);

            lData3.Content = string.Format(" {0}", Output.list[21].dt_txt);
            lTemperature3.Content = string.Format("{0:N1} \u00B0" + "C", Output.list[21].main.temp - 273.15);
            lPressure3.Content = string.Format("{0} hPa", Output.list[21].main.pressure);
            lHumidity3.Content = string.Format("{0} %", Output.list[21].main.humidity);
            lVwind3.Content = string.Format("{0} m/s", Output.list[21].wind.speed);
            icon3.Source = SetIcon(Output.list[21].weather[0].icon);

            
            DateTime actualtime = DateTime.Parse(Output.list[0].dt_txt);
           
            DateTime t22 = DateTime.Parse("2012/12/12 22:00:00.000");
            DateTime t6 = DateTime.Parse("2012/12/12 06:00:00.000");
           

            if (t22.TimeOfDay>actualtime.TimeOfDay && t6.TimeOfDay<actualtime.TimeOfDay)
            {               
                var uriSource = new Uri(@"/WeatherApp;component/Images/slonce.jpg", UriKind.Relative);
                backgroundImage.Source = new BitmapImage(uriSource);

            }
            else
            {
                var uriSource = new Uri(@"/WeatherApp;component/Images/morze-ksiezyc-noc-gory.jpeg", UriKind.Relative);
                backgroundImage.Source = new BitmapImage(uriSource);
            }

            }
            catch(Exception)
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

