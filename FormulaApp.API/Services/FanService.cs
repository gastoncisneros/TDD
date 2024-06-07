using FormulaApp.API.Configurations;
using FormulaApp.API.Models;
using FormulaApp.API.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace FormulaApp.API.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiServiceConfiguration _configuration;

        public FanService(HttpClient httpClient, IOptions<ApiServiceConfiguration> configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration.Value;
        }

        public async Task<List<Fan>?> GetAllFans()
        {
            var response = await _httpClient.GetAsync(_configuration.Url);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<Fan>();
            }

            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return null;
            }

            var fans = await response.Content.ReadFromJsonAsync<List<Fan>>();
            return fans;
        }
    }
}
