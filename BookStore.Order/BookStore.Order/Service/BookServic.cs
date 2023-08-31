using BookStore.Order.Entity;
using BookStore.Order.Interface;
using BookStore.Order.Model;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookStore.Order.Service
{
    public class BookServic : IBookServic
    {
        
        private readonly IHttpClientFactory _httpClientFactory;
        public BookServic(IHttpClientFactory _httpClientFactory)
        {
            this._httpClientFactory = _httpClientFactory;
        }


        //using Httpclient 
        //public async Task<BookEntity> GetBookDetails(int id)
        //{
        //HttpClient client = new HttpClient(); 
        //HttpResponseMessage response = await client.GetAsync($"https://localhost:7260/api/Book/GetBookbyId?id={id}");
        //if (response.IsSuccessStatusCode)
        //{
        //    string content = await response.Content.ReadAsStringAsync();
        //    ResponseModel apiResponseModel = JsonConvert.DeserializeObject<ResponseModel>(content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        BookEntity bookEntity = JsonConvert.DeserializeObject<BookEntity>(apiResponseModel.Data.ToString());
        //        return bookEntity;
        //    }
        //}
        //return null;
        //}

        //Using httpfactory
        public async Task<BookEntity> GetBookDetails(int id)
        {
            var client = _httpClientFactory.CreateClient("MyApi");
            var response = await client.GetAsync($"Book/GetBookbyId?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var apiResponseModel = await response.Content.ReadFromJsonAsync<ResponseModel>();

                //if (apiResponseModel != null && apiResponseModel.IsSucess)
                if (apiResponseModel != null)
                {
                    var bookEntity = JsonConvert.DeserializeObject<BookEntity>(apiResponseModel.Data.ToString());
                    return bookEntity;
                }
            }

            return null;

        }
    }
}
