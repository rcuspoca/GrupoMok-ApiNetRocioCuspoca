using APINetMok.Dominio.Contextos;
using APINetMok.Dominio.Entidades;
using APINetMok.Dto;
using APINetMok.Helper.Exceptions;
using APINetMok.Infraestructura.Interfaces;
using APINetMok.Models;
using APINetMok.Properties;
using Microsoft.EntityFrameworkCore;


namespace APINetMok.Infraestructura
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly PersistenciaContext _dbContext;         

        public PrestamoRepository(PersistenciaContext dbContext)
        {
            _dbContext = dbContext;          
        }

        public async Task<IEnumerable<PrestamoDto>> GetPrestamo()
        {
            try
            {
              return await (from _prestamo in _dbContext.PrestamoEntity
                              join libro in _dbContext.LibroEntity on _prestamo.IdLibro equals libro.IdLibro
                              join estudiante in _dbContext.EstudianteEntity on _prestamo.IdEstudiante equals estudiante.IdEstudiante
                              orderby libro.Nombre
                             select new PrestamoDto()
                             {
                                 IdPrestamo = _prestamo.IdPrestamo,
                                 IdLibro = _prestamo.IdLibro,
                                 NombreLibro = libro.Nombre,
                                 IdEstudiante = _prestamo.IdEstudiante,
                                 NombreEstudiante=estudiante.Nombres + " "+ estudiante.Apellidos,                                 
                                 Descripcion = _prestamo.Descripcion,
                                 FechaPrestamo = _prestamo.FechaPrestamo,
                                 FechaDevolucion= _prestamo.FechaDevolucion                                                            
                             }).ToListAsync();
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(Resource.FailedQuery, ex);
            }
        }

        public async Task<bool> AddPrestamo(PrestamoModel prestamo)
        {
            try
            {                         
                var PrestamoCreado = _dbContext.Add(BuildPrestamoEntity(prestamo));
                 await _dbContext.SaveChangesAsync();               

                prestamo.IdPrestamo = PrestamoCreado.Entity.IdPrestamo;
                return await Task.FromResult(true);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }
            catch (Exception ex)
            {                
                throw new Exception(Resource.FailedToSave, ex);
            }
        }

        private PrestamoEntity BuildPrestamoEntity(PrestamoModel prestamo)
        {
            return new PrestamoEntity()
            {
                IdPrestamo = prestamo.IdPrestamo,
                IdEstudiante = prestamo.IdEstudiante,
                IdLibro = prestamo.IdLibro,
                FechaPrestamo = prestamo.FechaPrestamo,
                FechaDevolucion = prestamo.FechaDevolucion,
                Descripcion = prestamo.Descripcion
            };
        }

        public async Task<bool> UpdatePrestamo(PrestamoModel prestamo)
        {
            try
            {
                var registroActualizar = await _dbContext.PrestamoEntity.Where(x => x.IdPrestamo == prestamo.IdPrestamo).FirstOrDefaultAsync();
                if (registroActualizar != null)
                {
                    _ = _dbContext.Update(BuildPrestamoEntity(prestamo));
                    await _dbContext.SaveChangesAsync();
                    return await Task.FromResult(true);
                }
                throw new BusinessException(Resource.RecordNotFound);

            }
            catch (BusinessException ex)
            {
                throw new BusinessException(Resource.RecordNotFound);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }
            catch (Exception ex)
            {               
                throw new Exception(Resource.FailedToSave, ex);
            }           
        }

        public async Task<bool> DeletePrestamo(int idPrestamo)
        {
            try
            {
                var registroARemover = await _dbContext.PrestamoEntity.Where(x => x.IdPrestamo == idPrestamo).FirstOrDefaultAsync();
               

                if (registroARemover != null)
                {
                    _ = _dbContext.Remove(registroARemover);
                    _ = _dbContext.SaveChanges();
                    return await Task.FromResult(true);
                }
                throw new BusinessException(Resource.RecordNotFound);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(Resource.RecordNotFound);
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(Resource.FailedToSave, ex);
            }            
        }  
    }
}
