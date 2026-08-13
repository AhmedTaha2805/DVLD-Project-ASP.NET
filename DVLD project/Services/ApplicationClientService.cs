using DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_project.Services
{
    public class ApplicationClientService
    {
        private readonly HttpClient _httpClient;
        public ApplicationClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/api/Application/");
        }
        public string GetStatus(int Appstatus)
        {
            switch (Appstatus)
            {
                case 1:
                    return "New";
                    break;
                case 2:
                    return "Cancelled";
                    break;
                case 3:
                    return "Completed";
                    break;
                default:
                    return "";
                    break;
            }
        }

        public async Task<ApplicationDTO> FindApplication(int AppId)
        {
            var response = await _httpClient.GetAsync($"FindApplication/{AppId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApplicationDTO>(json);
        }

        public async Task<ApplicationDTO> AddApplication(ApplicationDTO applicationDTO)
        {
            var jsonContent = JsonConvert.SerializeObject(applicationDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AddApplication", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ApplicationDTO>(json);
        }

        public async Task CancelApplication(int AppId)
        {
            var Response = await _httpClient.PutAsync($"CancelApplication/{AppId}", null);
            Response.EnsureSuccessStatusCode();
        }

        public async Task<int> GetNextId()
        {
            var response = await _httpClient.GetAsync($"GetNextId");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(json);

        }

        public async Task UpdateApplicationByPersonId(int AppId , int PersonId)
        {
            var Response = await _httpClient.PutAsync($"UpdateApplicationByPersonId/{AppId}/{PersonId}", null);
            Response.EnsureSuccessStatusCode();
            
        }

        public async Task UpdateApplication(ApplicationDTO applicationDTO)
        {
            var jsonContent = JsonConvert.SerializeObject(applicationDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var Response = await _httpClient.PutAsync($"UpdateApplication", content);
            Response.EnsureSuccessStatusCode();
        }

        public async Task DeleteApplication(int AppId)
        {
            var response = await _httpClient.DeleteAsync($"DeleteApplication/{AppId}");
            response.EnsureSuccessStatusCode();

        }
    }
}
