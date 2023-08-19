using APINetMok.Dto;
using APINetMok.Models;

namespace APINetMok.Infraestructura.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<IEnumerable<PrestamoDto>> GetPrestamo();

        Task<bool> AddPrestamo(PrestamoModel Prestamo);

        Task<bool> UpdatePrestamo(PrestamoModel Prestamo);

        Task<bool> DeletePrestamo(int idPrestamo);
    }
}
