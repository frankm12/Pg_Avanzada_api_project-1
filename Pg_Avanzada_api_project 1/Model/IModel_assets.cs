using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pg_Avanzada_api_project_1.Model
{
    public interface IModel_assets
    {
        Task<List<Root>> Conseguir_cryptos_generales();
    }
}
