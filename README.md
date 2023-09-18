# Rede Service

Este README fornece uma visão geral do projeto RedeService, explicando sua estrutura, modelos e serviços, e incluindo instruções sobre como usar e configurar o projeto.

## Descrição do Projeto

O projeto RedeService é uma aplicação .NET projetada para fornecer uma variedade de serviços relacionados à manipulação de arquivos, recuperação de dados, consultas de CEP 
(Código de Endereçamento Postal), informações bancárias e muito mais. A aplicação é composta por modelos que definem a estrutura de dados e serviços que realizam operações específicas.

## Estrutura do Projeto
O projeto é organizado em três principais áreas:

Modelos: Define as classes de modelos que representam diferentes tipos de dados usados na aplicação.

Serviços: Contém os serviços que realizam operações específicas, como manipulação de arquivos, consulta de CEP e obtenção de informações bancárias.

Controladores: Gerencia as rotas da aplicação e responde às solicitações do usuário, chamando os serviços apropriados.


### CorreiosService

O `CorreiosService` interage com os Correios (serviço postal brasileiro) para realizar consultas de CEP (Código de Endereçamento Postal) 
utilizando uma requisição SOAP com base no URL do WSDL do serviço e uma referência de serviço de dados do WCF.

#### Métodos Principais:

- `ConsultaCEPAsync(string cep)`: Recupera informações de endereço com base em um CEP de forma assíncrona, usando uma requisição SOAP ao serviço dos Correios.

- ### BankInfoService

O `BankInfoService` obtém informações sobre bancos de uma API externa (Brasil API) usando uma requisição HTTP via JSON com o HttpClient.

#### Métodos Principais:

- `GetBankInfo()`: Busca uma lista de informações bancárias de forma assíncrona, fazendo uma requisição HTTP à API do Brasil API e utilizando JSON para o transporte de dados.

Começando
1. Para começar com o projeto RedeService, siga estas etapas:

2. Clone o repositório do projeto no GitHub.

3. Abra a solução em sua IDE preferida (por exemplo, Visual Studio).

4. Compile a solução para garantir que todas as dependências sejam resolvidas.

5. Configure as configurações necessárias (consulte Configuração).

6. Execute a aplicação.

