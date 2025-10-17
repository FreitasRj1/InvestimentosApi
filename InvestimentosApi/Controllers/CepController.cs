using Microsoft.AspNetCore.Mvc;

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
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetCepInfo(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return BadRequest("Informe um CEP válido.");

            var url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return Ok(json);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao consultar CEP: {ex.Message}");
            }
        }
    }
}
