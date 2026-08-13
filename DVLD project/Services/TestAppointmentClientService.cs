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
    public class TestAppointmentClientService
    {
        private readonly HttpClient _httpClient;
        public TestAppointmentClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/api/TestAppointment/");
        }

        public async Task<TestAppointmentDTO> AddTestAppointment(TestAppointmentDTO testAppointmentDTO)
        {
            var jsonContent = JsonConvert.SerializeObject(testAppointmentDTO);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("AddTestAppointment", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TestAppointmentDTO>(json);
        }

        public async Task<int> GetNumberOfTrials(int LDLAppId, int testTypeId)
        {
            var response = await _httpClient.GetAsync($"GetNumberOfTrials/{LDLAppId}/{testTypeId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(json);
        }

        public async Task<List<TestAppointmentDTOForRetrieving>> GetTestAppointmentsByLDLAppId(int LDLAppId, int TestTypeId)
        {
            var response = await _httpClient.GetAsync($"GetTestAppointmentsByLDLAppId/{LDLAppId}/{TestTypeId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TestAppointmentDTOForRetrieving>>(json);
        }

        public async Task LockAppointment(int TestAppointmentId)
        {          
            var Response = await _httpClient.PutAsync($"LockAppointment/{TestAppointmentId}",null);
            Response.EnsureSuccessStatusCode();
        }

        public async Task<bool> HasUnLockedAppointment(int LDLAppId , int TestTypeId)
        {
            var response = await _httpClient.GetAsync($"HasUnLockedAppointment/{LDLAppId}/{TestTypeId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task UpdateAppointmentDate(int testAppointmentId, DateTime Date)
        {
            var Response = await _httpClient.PutAsync($"UpdateAppointmentDate/{testAppointmentId}/{Date}", null);
            Response.EnsureSuccessStatusCode();

        }

        public async Task DeleteAppointmentsWithLDLAppId(int LDLAppId)
        {
            var response = await _httpClient.DeleteAsync($"DeleteAppointmentsWithLDLAppId/{LDLAppId}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<int>> GetTestAppointmentsIdsByLDLAppId( int LDLAppId)
        {
            var response = await _httpClient.GetAsync($"GetTestAppointmentsIdsByLDLAppId/{LDLAppId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<int>>(json);
        }


    }
}
