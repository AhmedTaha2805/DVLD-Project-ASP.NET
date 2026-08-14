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
    public class InternationalLicenseClientService
    {
        private readonly HttpClient _httpClient;

        public InternationalLicenseClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _httpClient.BaseAddress =
                    new Uri("https://localhost:7008/api/InternationalLicense/");
        }
        public async Task<InternationalLicenseDTO> AddLicenseAsync(InternationalLicenseDTO dto)
        {
            var jsonContent = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var json =
                await response.Content.ReadAsStringAsync();

            var result =
                JsonConvert.DeserializeObject<InternationalLicenseDTO>(json);

            return result;
        }

        public async Task<bool> HasInternationalLicenseAsync(int licenseId)
        {
            var response =
                await _httpClient.GetAsync(
                    $"HasInternationalLicense/{licenseId}");

            response.EnsureSuccessStatusCode();

            var json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<InternationalLicenseDTO> FindLicenseByLicenseIdAsync(
            int licenseId)
        {
            var response =
                await _httpClient.GetAsync($"{licenseId}");

            response.EnsureSuccessStatusCode();

            var json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<InternationalLicenseDTO>(json);
        }

        public async Task<List<InternationalLicenseDTO>> ListIntLicensesAsync(
            int driverId)
        {
            var response =
                await _httpClient.GetAsync(
                    $"ByDriver/{driverId}");

            response.EnsureSuccessStatusCode();

            var json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<
                List<InternationalLicenseDTO>>(json);
        }

        public async Task<List<InternationalLicenseDTO>> ListAllIntLicensesAsync()
        {
            var response =
                await _httpClient.GetAsync("");

            response.EnsureSuccessStatusCode();

            var json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<
                List<InternationalLicenseDTO>>(json);
        }

        public async Task<DataTable> ListAllIntLicensesAsDataTableAsync()
        {
            var list = await ListAllIntLicensesAsync();

            DataTable dt = new DataTable();

            dt.Columns.Add("Int License ID", typeof(int));
            dt.Columns.Add("Application ID", typeof(int));
            dt.Columns.Add("Driver ID", typeof(int));
            dt.Columns.Add("L.License ID", typeof(int));
            dt.Columns.Add("Issue Date", typeof(DateTime));
            dt.Columns.Add("Expiration Date", typeof(DateTime));
            dt.Columns.Add("Is Active", typeof(bool));

            foreach (var item in list)
            {
                dt.Rows.Add(
                    item.InternationalLicenseId,
                    item.ApplicationId,
                    item.DriverId,
                    item.IssuedUsingLocalLicenseId,
                    item.IssueDate,
                    item.ExpirationDate,
                    item.IsActive
                );
            }

            return dt;
        }
    }
}
