using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebAPICLient1
{
    public class Sun
    {
        [JsonProperty("sunrise")]
        public string sunriseTime { get; set; }

        [JsonProperty("sunset")]
        public string sunsetTime { get; set; }

        [JsonProperty("solar_noon")]
        public string peakSunTime { get; set; }

        [JsonProperty("day_length")]
        public string dayLength { get; set; }

    }

    public class Result
    {
        [JsonProperty("results")]
        public Sun Sun { get; set; }
    }

    class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            await ProcessRespositories();
        }
        private static async Task ProcessRespositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Latitude and Longitude for New York is latitude = 40.7128 and longitude = -74.0060");
                    Console.WriteLine("Enter Latitude: ");
                    var lat = Console.ReadLine();
                    Console.WriteLine("Enter Longitude: ");
                    var lng = Console.ReadLine();
                    if (string.IsNullOrEmpty(lat) || string.IsNullOrEmpty(lng))
                    {
                        break;
                    }
                    var result = await _httpClient.GetAsync("https://api.sunrise-sunset.org/json?lat=" + lat + "&lng=" + lng + " ");
                    var resultRead = await result.Content.ReadAsStringAsync();
                    //Console.WriteLine(resultRead);

                    var sun = JsonConvert.DeserializeObject<Result>(resultRead);
                    Console.WriteLine("---");
                    Console.WriteLine("Sunrise: " + sun.Sun.sunriseTime);
                    Console.WriteLine("Sunset: " + sun.Sun.sunsetTime);
                    Console.WriteLine("Solar noon: " + sun.Sun.peakSunTime);
                    Console.WriteLine("Day length (Time fron sunrise to sunset): " + sun.Sun.dayLength);
                    Console.WriteLine("\n---");
                }
                catch (Exception)
                {
                    Console.WriteLine("Error, Please enter a vlaid latitude and longitude");
                }
            }

        }
    }
}