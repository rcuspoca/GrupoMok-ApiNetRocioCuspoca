using APINetMok.Dominio.Contextos;
using APINetMok.Dominio.Entidades;
using APINetMok.Dto;
using APINetMok.Helper.Exceptions;
using APINetMok.Infraestructura.Interfaces;
using APINetMok.Infraestructure.Interfaces;
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
    public class LibroRepository : ILibroRepository
    {
        private readonly PersistenciaContext _dbContext;             

        public LibroRepository(PersistenciaContext dbContext)
        {
            _dbContext = dbContext;          
        }

        public async Task<IEnumerable<LibroDto>> GetLibro()
        {
            try
            {
                return await (from _libro in _dbContext.LibroEntity
                              orderby _libro.Nombre
                             select new LibroDto()
                             {
                                 IdLibro = _libro.IdLibro,
                                 Codigo = _libro.Codigo,
                                 Nombre = _libro.Nombre,
                                 Autor = _libro.Autor,
                                 Editorial = _libro.Editorial,
                                 Precio = _libro.Precio,
                                 Ubicacion = _libro.Ubicacion,                                 
                                 Activo = _libro.Activo
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

        public async Task<bool> AddLibro(LibroDto libro)
        {
            try
            {               
                libro.Activo = true;
                var LibroCreado = _dbContext.Add(BuildLibroEntity(libro));
                 await _dbContext.SaveChangesAsync();               

                libro.IdLibro = LibroCreado.Entity.IdLibro;
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

        private LibroEntity BuildLibroEntity(LibroDto libro)
        {
            return new LibroEntity()
            {
                IdLibro = libro.IdLibro,
                Codigo = libro.Codigo,
                Nombre = libro.Nombre.ToUpper(),
                Autor = libro.Autor.ToUpper(),
                Editorial = libro.Editorial.ToUpper(),
                Precio = libro.Precio,
                Ubicacion = libro.Ubicacion,
                Activo = libro.Activo
            };
        }

        public async Task<bool> UpdateLibro(LibroDto libro)
        {
            try
            {
                var registroActualizar = await _dbContext.LibroEntity.Where(x => x.IdLibro == libro.IdLibro).FirstOrDefaultAsync();
                if (registroActualizar != null)
                {
                    _ = _dbContext.Update(BuildLibroEntity(libro));
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

        public async Task<bool> DeleteLibro(int idLibro)
        {
            try
            {
                if (await _dbContext.PrestamoEntity.Where(x => x.IdLibro == idLibro).FirstOrDefaultAsync() != null)
                    throw new BusinessException(Resource.ReferentialIntegrity);

                var registroARemover = await _dbContext.LibroEntity.Where(x => x.IdLibro == idLibro).FirstOrDefaultAsync();
               

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
