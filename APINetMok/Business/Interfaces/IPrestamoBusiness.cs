using APINetMok.Dto;
using APINetMok.Models;

namespace APINetMok.Business.Interfaces
{
    public interface IPrestamoBusiness
    {
        Task<IEnumerable<PrestamoDto>> GetPrestamoAsync();

        Task<bool> AddPrestamoAsync(PrestamoModel Prestamo);

        Task<bool> UpdatePrestamoAsync(PrestamoModel Prestamo);

        Task<bool> DeletePrestamoAsync(int idPrestamo);
    }
}
