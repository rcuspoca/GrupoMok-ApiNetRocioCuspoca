using APINetMok.Dominio.Contextos;
using APINetMok.Dominio.Entidades;
using APINetMok.Dto;
using APINetMok.Helper.Exceptions;
using APINetMok.Infraestructura.Interfaces;
using APINetMok.Models;
using APINetMok.Properties;
using APINetMok.Services;
using APINetMok.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Resources;
using System.Xml;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace APINetMok.Infraestructura
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly PersistenciaContext _dbContext;
        private readonly IServicioExternoApi _servicioExternoApi;       

        public EstudianteRepository(PersistenciaContext dbContext
            ,IServicioExternoApi servicioExternoApi )
        {
            _dbContext = dbContext;
            _servicioExternoApi = servicioExternoApi;


        }

        public async Task<IEnumerable<EstudianteDto>> GetEstudiante()
        {
            try
            {
                return await (from _estudiante in _dbContext.EstudianteEntity
                              orderby _estudiante.Apellidos
                             select new EstudianteDto()
                             {
                                 IdEstudiante = _estudiante.IdEstudiante,
                                 IdTipoIdentificacion = _estudiante.IdTipoIdentificacion,
                                 NumIdentificacion = _estudiante.NumIdentificacion,
                                 Nombres = _estudiante.Nombres,
                                 Apellidos = _estudiante.Apellidos,
                                 Direccion = _estudiante.Direccion,                                 
                                 Telefono = _estudiante.Telefono,
                                 Activo = _estudiante.Activo
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

        public async Task<bool> AddEstudiante(EstudianteDto estudiante)
        {
            try
            {
                // Invoca la Api Externa  que contiene los Tipos de Identificación
                 TipoIdentificacionModel tipoIdentificacion = 
                    await _servicioExternoApi.GetTipoDocumentoByAbreviatura(estudiante.TipoIdentificacion);

                estudiante.IdTipoIdentificacion = tipoIdentificacion.IdTipoIdentificacion;
                estudiante.Activo = true;

                var estudianteCreado = _dbContext.Add(BuildEstudianteEntity(estudiante));
                 await _dbContext.SaveChangesAsync();               

                estudiante.IdEstudiante = estudianteCreado.Entity.IdEstudiante;
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

        private EstudianteEntity BuildEstudianteEntity(EstudianteDto estudiante)
        {
            return new EstudianteEntity()
            {
                IdEstudiante = estudiante.IdEstudiante,
                IdTipoIdentificacion = estudiante.IdTipoIdentificacion,
                NumIdentificacion = estudiante.NumIdentificacion,
                Nombres = estudiante.Nombres.ToUpper(),
                Apellidos = estudiante.Apellidos.ToUpper(),
                Direccion = estudiante.Direccion,
                Telefono = estudiante.Telefono,
                Activo = estudiante.Activo
            };
        }

        public async Task<bool> UpdateEstudiante(EstudianteDto estudiante)
        {
            try
            {
                var registroActualizar = await _dbContext.EstudianteEntity.Where(x => x.IdEstudiante == estudiante.IdEstudiante).FirstOrDefaultAsync();
                if (registroActualizar != null)
                {
                    _ = _dbContext.Update(BuildEstudianteEntity(estudiante));
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

        public async Task<bool> DeleteEstudiante(int idEstudiante)
        {
            try
            {
                if (await _dbContext.PrestamoEntity.Where(x => x.IdEstudiante == idEstudiante).FirstOrDefaultAsync() != null)
                    throw new BusinessException(Resource.ReferentialIntegrity);

                var registroARemover = await _dbContext.EstudianteEntity.Where(x => x.IdEstudiante == idEstudiante).FirstOrDefaultAsync();
               

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
                throw new BusinessException(ex.Message);
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
