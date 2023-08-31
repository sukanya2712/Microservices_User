using BookStore.Order.Entity;

namespace BookStore.Order.HttpClientsDemo
{
    public class OrderHttpClient : IOrderHttpClient
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl;
        public OrderHttpClient(HttpClient httpClient) { this.httpClient = httpClient; }

        public async Task<List<OrderEntity>> Lists()
        {
            return await httpClient.GetFromJsonAsync<List<OrderEntity>>(baseUrl);
        }

    }
}

