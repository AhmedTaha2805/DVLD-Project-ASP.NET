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
    public class DetainedLicenseClientService
    {
            private readonly HttpClient _httpClient;

            public DetainedLicenseClientService()
            {
                _httpClient = new HttpClient();

                _httpClient.BaseAddress =
                    new Uri("https://localhost:7008/api/DetainedLicense/");
            }

            public async Task<DetainedLicenseDTO> DetainAsync(DetainedLicenseDTO dto)
            {
            var jsonContent = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);

                response.EnsureSuccessStatusCode();

                var json =
                    await response.Content.ReadAsStringAsync();

                var result =
                    JsonConvert.DeserializeObject<DetainedLicenseDTO>(json);

                return result;
            }

            public async Task ReleaseAsync(
                int id,
                DetainedLicenseDTO dto)
            {
            var jsonContent = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{id}/release", content);
            response.EnsureSuccessStatusCode();
            }

            public async Task<DetainedLicenseDTO> FindByDetainIdAsync(int id)
            {
                var response =
                    await _httpClient.GetAsync($"{id}");

                response.EnsureSuccessStatusCode();

                var json =
                    await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DetainedLicenseDTO>(json);
            }

            public async Task<DetainedLicenseDTO> FindByLicenseIdAsync(
                int licenseId)
            {
                var response =
                    await _httpClient.GetAsync(
                        $"ByLicense/{licenseId}");

                response.EnsureSuccessStatusCode();

                var json =
                    await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DetainedLicenseDTO>(json);
            }

            public async Task<List<DetainedLicenseViewDTO>> GetAllAsync()
            {
                var response =
                    await _httpClient.GetAsync("");

                response.EnsureSuccessStatusCode();

                var json =
                    await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<
                    List<DetainedLicenseViewDTO>>(json);
            }

        public async Task<DataTable> GetAllAsDataTableAsync()
        {
            var list = await GetAllAsync();

            DataTable dt = new DataTable();

            dt.Columns.Add("D.ID", typeof(int));
            dt.Columns.Add("L.ID", typeof(int));
            dt.Columns.Add("D.Date", typeof(DateTime));
            dt.Columns.Add("Is Released", typeof(bool));
            dt.Columns.Add("Fine Fees", typeof(decimal));
            dt.Columns.Add("Release Date", typeof(DateTime));
            dt.Columns.Add("N.No", typeof(string));
            dt.Columns.Add("Full Name", typeof(string));
            dt.Columns.Add("Release App ID", typeof(int));

            foreach (var item in list)
            {
                dt.Rows.Add(
                    item.DetainId,
                    item.LicenseId,
                    item.DetainDate,
                    item.IsReleased,
                    item.FineFees,
                    item.ReleaseDate ?? (object)DBNull.Value,
                    item.NationalNo,
                    item.FullName,
                    item.ReleaseApplicationId ?? (object)DBNull.Value
                );
            }

            return dt;
        }

    }
    }

