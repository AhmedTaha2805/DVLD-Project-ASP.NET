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
    public class TestTypeClientService
    {
        private readonly HttpClient _httpClient;
        public TestTypeClientService() {
            _httpClient = new HttpClient();  
            _httpClient.BaseAddress = new Uri("https://localhost:7008/");
        }

        public async Task<TestTypeDTO> GetTestTypeByID(int testtypeid)
        {
            var response = await _httpClient.GetAsync($"api/TestType/GetTestTypeById/{testtypeid}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TestTypeDTO>(json);
        }

        public async Task<List<TestTypeDTO>> GetAllTestTypes()
        {
            var response = await _httpClient.GetAsync("api/TestType/GetAllTestTypes");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TestTypeDTO>>(json);
        }

        public async Task UpdateTestType(TestTypeDTO testTypeDTO)
        {
            var jsonContent = JsonConvert.SerializeObject(testTypeDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("api/TestType/UpdateTestType", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
