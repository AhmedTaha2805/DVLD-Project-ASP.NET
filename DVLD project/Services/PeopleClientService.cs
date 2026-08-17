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
    public class PeopleClientService
    {
        private readonly HttpClient _httpClient;

        public PeopleClientService()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress =
                new Uri("https://localhost:7008/api/People/");
        }

        public async Task<PersonDTO> AddPersonAsync(PersonDTO dto)
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

            return JsonConvert.DeserializeObject<PersonDTO>(responseJson);
        }

        public async Task<List<PersonDTO>> GetAllPeopleAsync()
        {
            var response = await _httpClient.GetAsync("");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<PersonDTO>>(json);
        }

        public async Task<PersonDTO> FindPersonAsync(int id)
        {
            var response =
                await _httpClient.GetAsync($"{id}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PersonDTO>(json);
        }

        public async Task<PersonDTO> FindPersonByNationalNoAsync(
            string nationalNo)
        {
            var response =
                await _httpClient.GetAsync(
                    $"NationalNo/{nationalNo}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PersonDTO>(json);
        }

        public async Task<bool> NationalNoExistsAsync(
            string nationalNo)
        {
            var response =
                await _httpClient.GetAsync(
                    $"Exists/{nationalNo}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task UpdatePersonAsync(         
            PersonDTO dto)
        {
            string json =
                JsonConvert.SerializeObject(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response =
                await _httpClient.PutAsync(
                    "",
                    content);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePersonAsync(int id)
        {
            var response =
                await _httpClient.DeleteAsync($"{id}");

            response.EnsureSuccessStatusCode();

        }

        public async Task<DataTable> GetAllPeopleDataTableAsync()
        {
            var people = await GetAllPeopleAsync();

            DataTable dt = new DataTable();

            dt.Columns.Add("PersonId", typeof(int));
            dt.Columns.Add("NationalNo", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("SecondName", typeof(string));
            dt.Columns.Add("ThirdName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("DateOfBirth", typeof(DateTime));
            dt.Columns.Add("Gendor", typeof(byte));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("NationalityCountryId", typeof(int));
            dt.Columns.Add("ImagePath", typeof(string));

            foreach (var person in people)
            {
                dt.Rows.Add(
                    person.PersonId,
                    person.NationalNo,
                    person.FirstName,
                    person.SecondName,
                    person.ThirdName ?? "",
                    person.LastName,
                    person.DateOfBirth,
                    person.Gendor,
                    person.Address,
                    person.Phone,
                    person.Email ?? "",
                    person.NationalityCountryId,
                    person.ImagePath ?? ""
                );
            }

            return dt;
        }
    }
}
