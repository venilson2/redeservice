using Newtonsoft.Json;
using redeservice.Interfaces;
using redeservice.Models;

namespace redeservice.Services
{
    public class BankInfoService : IBankInfoService
    {
        private HttpClient _httpClient;

        public BankInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://brasilapi.com.br/api/banks/v1/");
        }

        public async Task<List<BankInfo>> GetBankInfo()
        {
            var response = await _httpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var bankInfoList = JsonConvert.DeserializeObject<List<BankInfo>>(content);
            return bankInfoList;
        }
    }
}
