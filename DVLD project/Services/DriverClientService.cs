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
    public class DriverClientService
    {
        private readonly HttpClient _httpClient;

        public DriverClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7008/api/Driver/");
        }

        public async Task<DriverDTO> AddDriverAsync(DriverDTO dto)
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

            return JsonConvert.DeserializeObject<DriverDTO>(responseJson);
        }

        public async Task<List<DriverViewDTO>> ListAllDriversAsync()
        {
            var response = await _httpClient.GetAsync(
                "");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<DriverViewDTO>>(json);
        }

        public async Task<bool> ThisDriverExistsAsync(int personID)
        {
            var response = await _httpClient.GetAsync(
                $"Exists/{personID}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<DriverDTO> FindDriverByIDAsync(int driverID)
        {
            var response = await _httpClient.GetAsync(
                $"{driverID}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DriverDTO>(json);
        }

        public async Task<DriverDTO> FindDriverByPersonIDAsync(int personID)
        {
            var response = await _httpClient.GetAsync(
                $"Person/{personID}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DriverDTO>(json);
        }

        public async Task<DataTable> ListAllDriversDataTableAsync()
        {
            var drivers = await ListAllDriversAsync();

            DataTable dt = new DataTable();

            dt.Columns.Add("DriverId", typeof(int));
            dt.Columns.Add("PersonId", typeof(int));
            dt.Columns.Add("NationalNo", typeof(string));
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("CreatedDate", typeof(DateTime));
            dt.Columns.Add("NumberOfActiveLicenses", typeof(int));

            foreach (var driver in drivers)
            {
                dt.Rows.Add(
                    driver.DriverId,
                    driver.PersonId,
                    driver.NationalNo,
                    driver.FullName,
                    driver.CreatedDate,
                    driver.NumberOfActiveLicenses ?? 0
                );
            }

            return dt;
        }
    }
}
