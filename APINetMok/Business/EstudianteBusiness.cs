using APINetMok.Business.Interfaces;
using APINetMok.Dto;
using APINetMok.Infraestructura.Interfaces;

namespace APINetMok.Business
{
    public class EstudianteBusiness : IEstudianteBusiness
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudianteBusiness(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<IEnumerable<EstudianteDto>> GetEstudianteAsync() => await _estudianteRepository.GetEstudiante();

        public async Task<bool> AddEstudianteAsync(EstudianteDto estudiante) => await _estudianteRepository.AddEstudiante(estudiante);

        public async Task<bool> UpdateEstudianteAsync(EstudianteDto estudiante) => await _estudianteRepository.UpdateEstudiante(estudiante);

        public async Task<bool> DeleteEstudianteAsync(int idEstudiante) => await _estudianteRepository.DeleteEstudiante(idEstudiante);
    }
}
