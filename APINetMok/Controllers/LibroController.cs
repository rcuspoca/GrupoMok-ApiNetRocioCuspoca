using APINetMok.Business.Interfaces;
using APINetMok.Dto;
using APINetMok.Helper.Exceptions;
using APINetMok.Helper.Extensions;
using APINetMok.Models;
using APINetMok.Properties;
using Microsoft.AspNetCore.Mvc;
using System.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINetMok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class LibroController : ControllerBase
    {
        private readonly ILibroBusiness _libroBusiness;

        public LibroController(ILibroBusiness libroBusiness)
        {
            _libroBusiness = libroBusiness;
        }
        /// <summary>
        /// Obtiene el listado de Libros
        /// </summary>
        /// <returns>Listado de empleados</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al consultar libros.</response>
   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroDto>>> Get()
        {
            try
            {
                return Ok(await _libroBusiness.GetLibroAsync());
            }

            catch (ValidationException be)
            {
                return StatusCode(StatusCodes.Status400BadRequest, be.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Se crea un libro
        /// </summary>
        /// <param name="libro"></param>
        /// <returns>Creación de un libro</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al crear un libro.</response>

        // POST api/<libroController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Post([FromBody] LibroDto libro)
        {
            try
            {
                _ = await _libroBusiness.AddLibroAsync(libro);
                return StatusCode(StatusCodes.Status201Created,
                    string.Format(Resource.SuccessfulCreation, Utilities.LIBRO, libro.Nombre));
            }
            catch (ValidationException be)
            {
                return StatusCode(StatusCodes.Status400BadRequest, be.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.IsNullOrEmpty(ex.Message) ? Resource.InternalServerError : ex.Message);
            }
        }

        // PUT api/<libroController>/5
        /// <summary>
        /// Se actualiza el registro de un libro seleccionado
        /// </summary>
        /// <param name="libro"></param>
        /// <returns>Actualización del registro de un libro</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al actualizar un libro.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Put([FromBody] LibroDto libro)
        {
            try
            {
                _ = await _libroBusiness.UpdateLibroAsync(libro);
                return StatusCode(StatusCodes.Status201Created,
                    string.Format(Resource.SuccessfulUpdate, Utilities.LIBRO, libro.Nombre));
            }
            catch (ValidationException be)
            {
                return StatusCode(StatusCodes.Status400BadRequest, be.Message);
            }
            catch (BusinessException exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.IsNullOrEmpty(ex.Message) ? Resource.InternalServerError : ex.Message);
            }
        }
        /// <summary>
        /// Se elimina un libro por Idlibro
        /// </summary>
        /// <param name="idlibro"></param>
        /// <returns>Eliminar un libro por Idlibro</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al actualizar un libro.</response>
        // DELETE api/<libroController>/5
        [HttpDelete("{idlibro}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Delete(int idlibro)
        {
            try
            {
                _ = await _libroBusiness.DeleteLibroAsync(idlibro);
                return StatusCode(StatusCodes.Status200OK,
                    string.Format(Resource.SuccessfulDelete, idlibro));
            }
            catch (ValidationException be)
            {
                return StatusCode(StatusCodes.Status400BadRequest, be.Message);
            }
            catch (BusinessException exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, exception.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.IsNullOrEmpty(ex.Message) ? Resource.InternalServerError : ex.Message);
            }
        }
    }
}
