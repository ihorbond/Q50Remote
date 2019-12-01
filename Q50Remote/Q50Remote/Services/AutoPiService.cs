using Newtonsoft.Json;
using Q50Remote.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Q50Remote.Services
{
    public class AutoPiService
    {
        HttpClient _httpClient;
        private const string BASE_URL = "https://api.autopi.io";
        private const string DEVICE_ID = "62b21593-f22a-4613-a73c-d6726bb7b6ee";
        private const string TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6Imlob3IiLCJ1c2VyX2lkIjo3MjIsImVtYWlsIjoiaWhvcmJvbmRAZ21haWwuY29tIiwiZXhwIjoxNTc1MjYyNTg0fQ.nBkbWcsi9Gs5wUcOpcqUV4PSh4TVr9yIQhQVkmsPzG0";
        public AutoPiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BASE_URL)
            };
        }

        public async Task SendCommand()
        {
            //string payload = "{\"CustomerId\": 5,\"CustomerName\": \"Pepsi\"}";
            //HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            await Task.Delay(3000);
        }

        public async Task<CarLocationModel> GetCarLocation()
        {
            string url = $"/logbook/most_recent_position/?device_id={DEVICE_ID}";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TOKEN);
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            CarLocationModel result = null;
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<CarLocationModel>(data);
            }

            return result;
            //return new CarLocationModel
            //{
            //    Location = new LatLanModel
            //    {
            //        Lat = 25,
            //        Lon = -80
            //    }
            //};
        }
    }
}
