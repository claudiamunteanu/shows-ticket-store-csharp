using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using app.model;
using app.persistence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestClient
{
    class MainClass
    {
        private static HttpClient client = new HttpClient();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            RunAsync().Wait();
        }

        private static Show show;

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:8080/app/shows/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            Show result = await GetShowAsync("http://localhost:8080/app/shows/3");
            Console.WriteLine("Am primit {0}", result);

            Console.WriteLine();
            List<Show> shows = await GetAllShowsAsync("http://localhost:8080/app/shows/");
            foreach (var show in shows)
            {
               Console.WriteLine(show); 
            }
            Console.WriteLine();
            
            show = new Show("Jennifer Lopez", DateTime.Parse("2021-03-19T20:30:00"), "Paris", 3500, 500);
            Show addedShow = await CreateShow("http://localhost:8080/app/shows/", show);
            Console.WriteLine(addedShow);
            Console.WriteLine();
            shows = await GetAllShowsAsync("http://localhost:8080/app/shows/");
            foreach (var show in shows)
            {
                Console.WriteLine(show); 
            }
            Console.WriteLine();

            show.Place = "Barcelona";
            show.AvailableSeats = 3000;
            show.SoldSeats = 1000;
            UpdateShow("http://localhost:8080/app/shows/", show);
            shows = await GetAllShowsAsync("http://localhost:8080/app/shows/");
            foreach (var show in shows)
            {
                Console.WriteLine(show); 
            }
            Console.WriteLine();

            DeleteShow("http://localhost:8080/app/shows/" + show.Id);
            shows = await GetAllShowsAsync("http://localhost:8080/app/shows/");
            foreach (var show in shows)
            {
                Console.WriteLine(show); 
            }
            Console.WriteLine();
        }

        static async Task<Show> GetShowAsync(string path)
        {
            Show product = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                String text = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<Show>(text);
            }
            System.Threading.Thread.Sleep(1000);
            return product;
        }

        static async Task<List<Show>> GetAllShowsAsync(String path)
        {
            List<Show> shows = null;
            HttpResponseMessage responseMessage = await client.GetAsync(path);
            if (responseMessage.IsSuccessStatusCode)
            {
                String text = await responseMessage.Content.ReadAsStringAsync();
                shows = JsonConvert.DeserializeObject<List<Show>>(text);
                show = shows[shows.Count - 1];
            }
            System.Threading.Thread.Sleep(1000);
            return shows;
        }

        static async Task<Show> CreateShow(String path, Show s)
        {
            string json = DeserializeJson(s);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(path, httpContent);

            Show addedShow = null; 
            if (responseMessage.IsSuccessStatusCode)
            {
                String text = await responseMessage.Content.ReadAsStringAsync();
                addedShow = JsonConvert.DeserializeObject<Show>(text);
            }
            System.Threading.Thread.Sleep(1000);
            return addedShow;
        }

        static async void DeleteShow(string path)
        {
            await client.DeleteAsync(path);
            System.Threading.Thread.Sleep(2000);
        }

        static async void UpdateShow(string path, Show s)
        {
            string json = DeserializeJson(s);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PutAsync(path, httpContent);
            System.Threading.Thread.Sleep(1000);
        }

        static string DeserializeJson(Show s)
        {
            string json = JsonConvert.SerializeObject(s);

            Dictionary<string,string> dict = json.Substring(1, json.Length - 2)
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(part => part.Split(new []{':'}, 2))
                .ToDictionary(split=>split[0], split => split[1]);
            
            foreach (var key in dict.Keys.ToList())
            {
                var newKey = key.First() + key.Substring(1, 1).ToLower() + key.Substring(2);
                dict.Add(newKey, dict[key]);
                dict.Remove(key);
            }
            
            var entries = dict.Select(d =>
                string.Format("{0}:{1}", d.Key, d.Value));
            return "{" + string.Join(",", entries) + "}";
        }
    }
}