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
    public class LicenseClientService
    {
        private readonly HttpClient _httpClient;

        public LicenseClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/api/License/");
        }
        public async Task<LicenseDTO> AddLicenseAsync(LicenseDTO dto)
        {
            string json = JsonConvert.SerializeObject(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(
                "",
                content);

            response.EnsureSuccessStatusCode();

            string responseJson =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LicenseDTO>(responseJson);
        }

        public async Task<LicenseDTO> FindLicenseByApplicationIDAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"Application/{id}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LicenseDTO>(json);
        }

        public async Task<LicenseDTO> FindLicenseByLicenseIDAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"{id}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LicenseDTO>(json);
        }

        public async Task<string> GetIssueReasonAsync(int n)
        {
            var response = await _httpClient.GetAsync(
                $"IssueReason/{n}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> IsDetainedAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"{id}/Detained");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<bool> WasDetainedAndReleasedAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"{id}/WasDetainedAndReleased");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<List<LicenseDTO>> ListLocalLicensesAsync(int driverID)
        {
            var response = await _httpClient.GetAsync(
                $"Driver/{driverID}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<LicenseDTO>>(json);
        }

        public async Task<bool> IsExpiredAsync(int licenseID, DateTime date)
        {
            var response = await _httpClient.GetAsync(
                $"{licenseID}/Expired?date={date:O}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<bool> IsLicenseActiveAsync(int licenseID)
        {
            var response = await _httpClient.GetAsync(
                $"{licenseID}/Active");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task DeActivateLicenseAsync(int licenseID)
        {
            var response = await _httpClient.PutAsync(
                $"{licenseID}/Deactivate",
                null);

            response.EnsureSuccessStatusCode();
        }

        public async Task ActivateLicenseAsync(int licenseID)
        {
            var response = await _httpClient.PutAsync(
                $"{licenseID}/Activate",
                null);

            response.EnsureSuccessStatusCode();
        }
    }
}
