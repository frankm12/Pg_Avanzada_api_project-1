using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pg_Avanzada_api_project_1.View
{
    public interface IViewFormulario_Principal
    {
        void MostrarDatos(object datos);
        void MostrarError(string mensaje);
        event EventHandler OnDatosRequeridos;
    }
}
