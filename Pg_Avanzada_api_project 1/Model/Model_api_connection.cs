using Newtonsoft.Json;
using Pg_Avanzada_api_project_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pg_Avanzada_api_project_1
{
    public class Model_api_connection
    {
        private readonly HttpClient _httpClient;

        public Model_api_connection()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MyApp/1.0)");
        }

        private const string ApiUrl = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd";

        public async Task<List<Root>> ObtenerDatosCriptoAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error HTTP: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Root>>(json) ?? new List<Root>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de la API", ex);
            }
        }
    }
}
