using APINetMok.Business.Interfaces;
using APINetMok.Dto;
using APINetMok.Infraestructure.Interfaces;

namespace APINetMok.Business
{
    public class LibroBusiness : ILibroBusiness
    {
        private readonly ILibroRepository _libroRepository;

        public LibroBusiness(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public async Task<IEnumerable<LibroDto>> GetLibroAsync() => await _libroRepository.GetLibro();

        public async Task<bool> AddLibroAsync(LibroDto libro) => await _libroRepository.AddLibro(libro);

        public async Task<bool> UpdateLibroAsync(LibroDto libro) => await _libroRepository.UpdateLibro(libro);

        public async Task<bool> DeleteLibroAsync(int idLibro) => await _libroRepository.DeleteLibro(idLibro);
    }
}
