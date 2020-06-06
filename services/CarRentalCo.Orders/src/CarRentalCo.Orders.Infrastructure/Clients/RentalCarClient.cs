using CarRentalCo.Orders.Application.Orders.Clients;
using CarRentalCo.Orders.Application.Orders.Dtos;
using CarRentalCo.Orders.Application.Settings;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCo.Orders.Infrastructure.Clients
{
    //todo refactor
    public class RentalCarClient : IRentalCarClient
    {
        private readonly RentalCarClientSettings settings;
        HttpClient httpClient;
        public RentalCarClient(IHttpClientFactory httpClientFactory, RentalCarClientSettings settings )
        {
            this.settings = settings;
            httpClient = httpClientFactory.CreateClient(nameof(RentalCarClient));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.1 (KHTML, like Gecko) Chrome/14.0.835.202 Safari/535.1");
        }


        public async Task<RentalCarDto> GetByIdAsync(Guid id)
        {
            var uri = new Uri($"{settings.BasePath}/{settings.RentalCarEndpoint}/{id}");

            var response = await httpClient.GetAsync(uri);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return default;
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RentalCarDto>(json);

            return result;
        }

        public async Task<ICollection<RentalCarDto>> GetByIdsAsync(Guid[] ids)
        {
            var uri = new Uri($"{settings.BasePath}/{settings.RentalCarEndpoint}");

            var request = new HttpRequestMessage();
            var body = JsonConvert.SerializeObject(new RentalCarBody { RentalCarIds = ids });
            request.Content = new StringContent(body,Encoding.UTF8, "application/json");
            request.RequestUri = uri;
            request.Method = HttpMethod.Get;
            
            var response = await httpClient.SendAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return default;
            }

            var json =  await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ICollection<RentalCarDto>>(json);

            return result;
        }

        class RentalCarBody
        {
            public Guid[] RentalCarIds { get; set; }
        }
    }
}
