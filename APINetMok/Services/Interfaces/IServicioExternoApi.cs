using APINetMok.Models;

namespace APINetMok.Services.Interfaces
{
    public interface IServicioExternoApi
    {
        Task<TipoIdentificacionModel> GetTipoDocumentoByAbreviatura(string abreviatura);
    }
}
