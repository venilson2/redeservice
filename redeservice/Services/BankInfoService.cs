using redeservice.Interfaces;
using redeservice.Models;
using System.Text.Json;

namespace redeservice.Services
{
    public class BankInfoService : IBankInfoService
    {
        private readonly HttpClient _httpClient;

        public BankInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://brasilapi.com.br/api/banks/v1/");
        }

        public async Task<List<BankInfo>> GetBankInfo()
        {
            var response = await _httpClient.GetAsync("bancos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var bankInfoList = JsonSerializer.Deserialize<List<BankInfo>>(content);
            return bankInfoList;
        }
    }
}
