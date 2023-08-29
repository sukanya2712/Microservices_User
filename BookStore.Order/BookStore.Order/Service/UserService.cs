using BookStore.Order.Entity;
using BookStore.Order.Interface;
using BookStore.Order.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace BookStore.Order.Service
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration) { this._configuration = configuration; }

        public async Task<UserEntity> GetUserDetails(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync($"https://localhost:7029/api/User/Display");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ResponseModel apiResponseModel = JsonConvert.DeserializeObject<ResponseModel>(content);

                if (response.IsSuccessStatusCode)
                {
                    UserEntity userEntity = JsonConvert.DeserializeObject<UserEntity>(apiResponseModel.Data.ToString());
                    return userEntity;
                }

            }
            return null;

        }
    }
}

