using APINetMok.Dominio.Entidades;
using APINetMok.Dto;
using APINetMok.Models;

namespace APINetMok.Infraestructura.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<EstudianteDto>> GetEstudiante();

        Task<bool> AddEstudiante(EstudianteDto estudiante);

        Task<bool> UpdateEstudiante(EstudianteDto estudiante);

        Task<bool> DeleteEstudiante(int idEstudiante);
    }
}
