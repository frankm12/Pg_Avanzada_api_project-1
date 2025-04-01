using Pg_Avanzada_api_project_1.Model;
using Pg_Avanzada_api_project_1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pg_Avanzada_api_project_1.Presenter
{
    public class Presenter_crypto_general
    {
        // aqui aplico la interfaz del view
        private readonly IViewFormulario_Principal _view;
        private readonly Model_api_connection _model;

        public Presenter_crypto_general(IViewFormulario_Principal view)
        {
            _view = view;
            _model = new Model_api_connection();
            // tener en cuenta de darle el evento en el constructor, y decirle donde estara localizado ese evento
            _view.OnDatosRequeridos += OnDatosRequeridos;
        }

        private async void OnDatosRequeridos(object sender, EventArgs e)
        {
            try
            {
                //aqui llamamos el metodo que tenemos en el model para obtener la api
                var datosCompletos = await _model.ObtenerDatosCriptoAsync();

                if (datosCompletos == null || !datosCompletos.Any())
                {
                    _view.MostrarError("No se recibieron datos de la API");
                    return;
                }

                var datosFiltrados = datosCompletos.Select(c => new
                {
                    ID = c.id,
                    Símbolo = c.symbol?.ToUpper() ?? "N/A",
                    Precio = c.priceUsd
                }).ToList();

                _view.MostrarDatos(datosFiltrados);
            }
            catch (Exception ex)
            {
                // Muestra el stack trace completo para depuración
                _view.MostrarError($"Error al obtener datos: {ex.ToString()}");
            }

        }
    }
}
