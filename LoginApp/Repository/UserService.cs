using LoginApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoginApp.Repository
{
    public class UserService : IUserRepository
    {
        public async Task<User> Login(string email, string password)
        {
            var client = new HttpClient();
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                             ? "http://10.0.2.2:5025"
                             : "http://localhost:5025";
            string url = $"{baseUrl}/api/User/"+email + "/" + password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if(response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(content);
                return await Task.FromResult(user);
            }
            return null;
        }
    }
}
