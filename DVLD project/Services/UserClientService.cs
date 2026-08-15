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
    public class UserClientService
    {
        private readonly HttpClient _httpClient;

        public UserClientService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress =
                new Uri("https://localhost:7008/api/User/");
        }

        public async Task<UserDTO> AddUserAsync(UserDTO dto)
        {
            string json =
                JsonConvert.SerializeObject(dto);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response =
                await _httpClient.PostAsync(
                    "",
                    content);

            response.EnsureSuccessStatusCode();

            string responseJson =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(
                responseJson);
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var response =
                await _httpClient.GetAsync("");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<UserDTO>>(
                json);
        }

        public async Task<UserDTO> FindUserAsync(int userID)
        {
            var response =
                await _httpClient.GetAsync(
                    $"{userID}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(
                json);
        }

        public async Task<bool> FindUserByPersonIDAsync(
            int personID)
        {
            var response =
                await _httpClient.GetAsync(
                    $"Person/{personID}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(json);
        }

        public async Task<UserDTO> FindUserAsync(
            string username,
            string password)
        {
            var response =
                await _httpClient.GetAsync(
                    $"Login?username={username}&password={password}");

            response.EnsureSuccessStatusCode();

            string json =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(
                json);
        }

        public async Task<UserDTO> UpdateUserAsync(
            UserDTO dto)
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

            string responseJson =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(
                responseJson);
        }

        public async Task DeleteUserAsync(int id)
        {
            var response =
                await _httpClient.DeleteAsync(
                    $"{id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<DataTable> GetAllUsersDataTableAsync()
        {
            var users =
                await GetAllUsersAsync();

            DataTable dt = new DataTable();

            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("PersonID", typeof(int));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("IsActive", typeof(bool));

            foreach (var user in users)
            {
                dt.Rows.Add(
                    user.UserId,
                    user.PersonId,
                    user.UserName,
                    user.Password,
                    user.IsActive
                );
            }

            return dt;
        }
    }
}
