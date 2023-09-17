using redeservice.Interfaces;
using redeservice.Models;
using ServiceReference1;
using System.ServiceModel;

namespace redeservice.Services
{
    public class CorreiosService : ICorreiosService
    {
        public async Task<ConsultaCEPResponse> ConsultaCEPAsync(string cep)
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None; 
            var endpoint = new EndpointAddress("https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente");

            using (var client = new AtendeClienteClient(binding, endpoint))
            {
                var consultaCEPResponse = await client.consultaCEPAsync(cep);

                var result = new ConsultaCEPResponse
                {
                    Bairro = consultaCEPResponse.@return.bairro,
                    CEP = consultaCEPResponse.@return.cep,
                    Cidade = consultaCEPResponse.@return.cidade,
                    Complemento2 = consultaCEPResponse.@return.complemento2,
                    End = consultaCEPResponse.@return.end,
                    UF = consultaCEPResponse.@return.uf
                };

                return result;
            }
        }
    }
}
