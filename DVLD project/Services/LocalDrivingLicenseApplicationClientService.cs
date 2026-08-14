using DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_project.Services
{
    public class LocalDrivingLicenseApplicationClientService
    {
        private readonly HttpClient _httpClient;
        public LocalDrivingLicenseApplicationClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/api/LocalDrivingLicenseApplication/");
        }
        public async Task<LocalDrivingLicenseApplicationDTO> FindApplicationAsync(int id)
        {
            var response = await _httpClient.GetAsync(
                $"{id}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LocalDrivingLicenseApplicationDTO>(json);
        }

        public async Task<LocalDrivingLicenseApplicationDTO> AddApplicationAsync(LocalDrivingLicenseApplicationDTO dto)
        {
            var jsonContent = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LocalDrivingLicenseApplicationDTO>(json);
        }

        public async Task<List<LocalDrivingLicenseApplicationsViewDTO>> GetAllLocalAppsAsync()
        {
            var response = await _httpClient.GetAsync(
                "");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<LocalDrivingLicenseApplicationsViewDTO>>(json);
        }

        public async Task<int> FindNumberOfPassedTestsAsync(int LocalAppID)
        {
            var response = await _httpClient.GetAsync(
                $"NumberOfPassedTests/{LocalAppID}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(json);
        }

        public async Task<bool> ThereIsDuplicateAppAsync(
            int PersonID,
            int LicenseClassID)
        {
            var response = await _httpClient.GetAsync(
                $"ThereIsDuplicateApp/{PersonID}/{LicenseClassID}");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task UpdateApplicationAsync(
            LocalDrivingLicenseApplicationDTO dto)
        {
            var jsonContent = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("", content);
           
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<DataTable> GetAllLocalAppsAsDataTableAsync()
        {
            var list = await GetAllLocalAppsAsync();

            DataTable dt = new DataTable();

            dt.Columns.Add("L.D.L AppID", typeof(int));
            dt.Columns.Add("Driving Class", typeof(string));
            dt.Columns.Add("National No", typeof(string));
            dt.Columns.Add("Full Name", typeof(string));
            dt.Columns.Add("Application Date", typeof(DateTime));
            dt.Columns.Add("Passed Tests", typeof(int));
            dt.Columns.Add("Status", typeof(string));

            foreach (var item in list)
            {
                dt.Rows.Add(
                    item.LocalDrivingLicenseApplicationId,
                    item.ClassName,
                    item.NationalNo,
                    item.FullName,
                    item.ApplicationDate,
                    item.PassedTestCount ?? 0,
                    item.Status
                );
            }

            return dt;
        }
    }
}
