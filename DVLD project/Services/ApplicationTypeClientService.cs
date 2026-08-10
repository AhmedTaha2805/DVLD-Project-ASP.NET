using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_project.Services
{
    public class ApplicationTypeClientService
    {
        private readonly HttpClient _httpClient;
        public ApplicationTypeClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/");
        }

        public async Task<List<ApplicationTypeDTO>> GetAllApplicationTypes()
        {
            var response = await _httpClient.GetAsync("api/ApplicationType/GetAllApplicationTypes");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ApplicationTypeDTO>>(json);
        }
        public async Task<ApplicationTypeDTO> GetApplicationTypeById(int id)
        {
            var response = await _httpClient.GetAsync($"api/ApplicationType/GetApplicationTypeById/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ApplicationTypeDTO>(json);
        }

        public async Task<string> GetApplicationTypeTitleById(int id)
        {
            var response = await _httpClient.GetAsync($"api/ApplicationType/GetApplicationTypeTitleById/{id}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<string>(json);
        }

        public async Task UpdateApplicationType(ApplicationTypeDTO applicationTypeDTO)
        {
            var jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(applicationTypeDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"api/ApplicationType/{applicationTypeDTO.ApplicationTypeId}", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
