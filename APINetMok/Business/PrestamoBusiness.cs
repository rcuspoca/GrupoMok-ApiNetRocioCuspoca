using APINetMok.Business.Interfaces;
using APINetMok.Dto;
using APINetMok.Infraestructura.Interfaces;
using APINetMok.Models;

namespace APINetMok.Business
{
    public class PrestamoBusiness : IPrestamoBusiness
    {
        private readonly IPrestamoRepository _PrestamoRepository;

        public PrestamoBusiness(IPrestamoRepository PrestamoRepository)
        {
            _PrestamoRepository = PrestamoRepository;
        }

        public async Task<IEnumerable<PrestamoDto>> GetPrestamoAsync() => await _PrestamoRepository.GetPrestamo();

        public async Task<bool> AddPrestamoAsync(PrestamoModel prestamo) => await _PrestamoRepository.AddPrestamo(prestamo);

        public async Task<bool> UpdatePrestamoAsync(PrestamoModel prestamo) => await _PrestamoRepository.UpdatePrestamo(prestamo);

        public async Task<bool> DeletePrestamoAsync(int idPrestamo) => await _PrestamoRepository.DeletePrestamo(idPrestamo);
    }
}
