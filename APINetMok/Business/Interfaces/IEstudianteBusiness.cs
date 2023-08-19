using APINetMok.Dto;
using APINetMok.Models;

namespace APINetMok.Business.Interfaces
{
    public interface IEstudianteBusiness
    {
        Task<IEnumerable<EstudianteDto>> GetEstudianteAsync();

        Task<bool> AddEstudianteAsync(EstudianteDto estudiante);

        Task<bool> UpdateEstudianteAsync(EstudianteDto estudiante);

        Task<bool> DeleteEstudianteAsync(int idEstudiante);
    }
}
