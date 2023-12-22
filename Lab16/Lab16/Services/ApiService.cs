using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using Lab16.Models;

namespace Lab16.Services
{
    public class ApiService
    {
        public async Task<List<User>> GetUsersAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://laboratorio16-api.vercel.app/api/user");
            var users = JsonConvert.DeserializeObject<List<User>>(response);
            return users;
        }
    }
}
    