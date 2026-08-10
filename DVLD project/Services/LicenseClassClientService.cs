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
    public class LicenseClassClientService
    {
        private readonly HttpClient _httpClient;
        public LicenseClassClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/api/LicenseClass/");
        }
        public async Task<List<LicenseClassDTO>> GetAllLicenseClasses()
        {
            var response = await _httpClient.GetAsync("GetAllLicenseClasses");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LicenseClassDTO>>(json);
        }
        public async Task<int> GetLicenseClassIdByClassName(string ClassName)
        {
            var response = await _httpClient.GetAsync($"GetLicenseClassIdByClassName/{ClassName}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(json);
        }
        public async Task<string> GetLicenseClassNameById(int LicenseClassId)
        {
            var response = await _httpClient.GetAsync($"GetLicenseClassNameById/{LicenseClassId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<decimal> GetLicenseClassFeesById(int LicenseClassId)
        {
            var response = await _httpClient.GetAsync($"GetLicenseClassFeesById/{LicenseClassId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<decimal>(json);
        }
        public async Task<Byte> GetLicenseClassValidityLengthById(int LicenseClassId)
        {
            var response = await _httpClient.GetAsync($"GetLicenseClassValidityLengthById/{LicenseClassId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Byte>(json);
        }
    }
}
