using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;

namespace DVLD_project.Services
{
    public class CountryClientService
    {
        private readonly HttpClient _httpClient;
        public CountryClientService() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/");
        }

        public async Task<string> GetCountryName(int countryid)
        {
            var response = await _httpClient.GetAsync($"api/Country/GetCountryName/{countryid}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<CountryDTO>> GetAllCountries()
        {
            var response = await _httpClient.GetAsync("api/Country/GetAllCountries");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CountryDTO>>(json);
        }
    }
}
