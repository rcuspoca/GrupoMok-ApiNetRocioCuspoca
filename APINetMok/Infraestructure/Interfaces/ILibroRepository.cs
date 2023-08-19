using APINetMok.Dto;

namespace APINetMok.Infraestructure.Interfaces
{
    public interface ILibroRepository
    {
        Task<IEnumerable<LibroDto>> GetLibro();

        Task<bool> AddLibro(LibroDto libro);

        Task<bool> UpdateLibro(LibroDto libro);

        Task<bool> DeleteLibro(int idLibro);
    }
}
