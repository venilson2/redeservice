using redeservice.Models;

namespace redeservice.Interfaces
{
    public interface ICorreiosService
    {
        Task<ConsultaCEPResponse> ConsultaCEPAsync(string cep);
    }
}
