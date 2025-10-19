using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace InvestimentosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CepController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetCepInfo(string cep)
        {
            cep = cep.Replace("-", "").Trim();

            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
                return BadRequest("Informe um CEP válido com 8 dígitos.");

            var url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return StatusCode((int)response.StatusCode, "Erro ao consultar o serviço ViaCEP.");

                var json = await response.Content.ReadAsStringAsync();
                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao consultar CEP: {ex.Message}");
            }
        }
    }
}
