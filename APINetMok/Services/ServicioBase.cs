using System.Globalization;

namespace APINetMok.Services
{
    public class ServicioBase
    {
        public IConfiguration Configuration { get; }

        public ServicioBase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Devuelve la URL del servicio que se va a consumir
        /// </summary>
        /// <returns></returns>
        public string ObtenerUrlApi(string ApiTag)
        {
            string abreviacionAmbiente = Configuration.GetValue<string>("RunWithConfiguration:EnvironmentName").ToLower();
            string nombreConfiguracionUrl = string.Format("{0}{1}", CultureInfo.InvariantCulture.TextInfo.ToTitleCase(abreviacionAmbiente), "Url");
            string urlBase = Configuration.GetValue<string>(ApiTag + ":" + nombreConfiguracionUrl);
            return urlBase;
        }

    }
}
