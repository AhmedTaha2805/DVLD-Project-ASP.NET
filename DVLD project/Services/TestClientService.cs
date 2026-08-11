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
    public class TestClientService
    {
        private readonly HttpClient _httpClient;
        public TestClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/api/Test/");
        }

        public async Task DeleteTestWithAppointmentId(int appointmentId)
        {
            var response = await _httpClient.DeleteAsync($"DeleteTestWithAppointmentID/{appointmentId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> PersonPassedThisTestBefore(int localDrivingLicenseAppId, int testId)
        {
            var response = await _httpClient.GetAsync($"PersonPassedThisTestBefore/{localDrivingLicenseAppId}/{testId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<bool> PersonFailedThisTestBefore(int localDrivingLicenseAppId, int testId)
        {
            var response = await _httpClient.GetAsync($"PersonFailedThisTestBefore/{localDrivingLicenseAppId}/{testId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<TestDTO> AddTest(TestDTO testDTO)
        {
            var jsonContent = JsonConvert.SerializeObject(testDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AddTest", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TestDTO>(json);
        }


    }
}
