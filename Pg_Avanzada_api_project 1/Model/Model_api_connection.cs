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
        private readonly HttpClient _httpClient = new HttpClient();
        //hacemos una variable tipo constante para que no se cambie en el transcurso del uso del programa
        private const string ApiUrl = "https://api.coincap.io/v2/assets";

        public async Task<List<Root>> ObtenerDatosCriptoAsync()
        {
            try
            {
                // aqui usamos el metodo getasync que se encuentra en la libreria json que instalamos al principio
                // con este metodos consultamos la api
                var response = await _httpClient.GetAsync(ApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error HTTP: {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                // Se utiliza el var para que los datos sean de tipo implicito es decir que se puedan convertir a cual necesite en el proceso de compilación
                //En en deserializeobject hago que la respuesta trabaje dentro de la clase en la cual se va a pasar la data
                var apiResponse = JsonConvert.DeserializeObject<CoinCapApiResponse>(json);
                return apiResponse?.Data ?? new List<Root>();
            }
            // aqui capturamos cualquier error que pueda dar la api
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos de la API", ex);
            }
        }
    }

    // se hace esta clase para enlistar la respuesta de la api y pueda ser manipulable
    public class CoinCapApiResponse
    {
        public List<Root> Data { get; set; }
    }
    
}
