using redeservice.Models;

namespace redeservice.Interfaces
{
    public interface IBankInfoService
    {
        Task<List<BankInfo>> GetBankInfo();
    }
}
