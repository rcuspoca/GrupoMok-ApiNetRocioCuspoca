using APINetMok.Helper.HttpClientHelper;
using APINetMok.Models;
using APINetMok.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace APINetMok.Services
{
    public class ServicioExternoApi : ServicioBase, IServicioExternoApi
    {
        private readonly ExternoApiSettings _servicioExternoApiEndPoint;

        public new IConfiguration Configuration { get; }

        public ServicioExternoApi(IOptions<ExternoApiSettings> servicioExternoApiEndPoint
            , IConfiguration configuration) : base(configuration)
        {
            _servicioExternoApiEndPoint = servicioExternoApiEndPoint.Value;
            Configuration = configuration;

        }

        public async Task<TipoIdentificacionModel> GetTipoDocumentoByAbreviatura(string abreviatura)
        {
            TipoIdentificacionModel tipoIdentificacion = await ClientConnection
               .GetAsync<TipoIdentificacionModel>(ObtenerUrlApi("ServicioExternoApi") + abreviatura);

            return tipoIdentificacion ?? new TipoIdentificacionModel();
        }
    }
}
