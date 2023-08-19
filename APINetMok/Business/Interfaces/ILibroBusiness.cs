using APINetMok.Dto;
using APINetMok.Models;

namespace APINetMok.Business.Interfaces
{
    public interface ILibroBusiness
    {
        Task<IEnumerable<LibroDto>> GetLibroAsync();

        Task<bool> AddLibroAsync(LibroDto libro);

        Task<bool> UpdateLibroAsync(LibroDto libro);

        Task<bool> DeleteLibroAsync(int idLibro);
    }
}
