using APINetMok.Business.Interfaces;
using APINetMok.Dto;
using APINetMok.Helper.Exceptions;
using APINetMok.Helper.Extensions;
using APINetMok.Models;
using APINetMok.Properties;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APINetMok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoBusiness _prestamoBusiness;

        public PrestamoController(IPrestamoBusiness prestamoBusiness)
        {
            _prestamoBusiness = prestamoBusiness;
        }
        /// <summary>
        /// Obtiene el listado de Prestamos
        /// </summary>
        /// <returns>Listado de empleados</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al consultar Prestamos.</response>
   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrestamoDto>>> Get()
        {
            try
            {
                return Ok(await _prestamoBusiness.GetPrestamoAsync());
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
        /// Se crea un Prestamo
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns>Creación de un Prestamo</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al crear un Prestamo.</response>

        // POST api/<PrestamoController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Post([FromBody] PrestamoModel prestamo)
        {
            try
            {
                _ = await _prestamoBusiness.AddPrestamoAsync(prestamo);
                return StatusCode(StatusCodes.Status201Created,
                    string.Format(Resource.SuccessfulCreation, Utilities.PRESTAMO, prestamo.Descripcion));
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

        // PUT api/<PrestamoController>/5
        /// <summary>
        /// Se actualiza el registro de un Prestamo seleccionado
        /// </summary>
        /// <param name="prestamo"></param>
        /// <returns>Actualización del registro de un Prestamo</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al actualizar un Prestamo.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Put([FromBody] PrestamoDto prestamo)
        {
            try
            {
                _ = await _prestamoBusiness.UpdatePrestamoAsync(prestamo);
                return StatusCode(StatusCodes.Status201Created,
                    string.Format(Resource.SuccessfulUpdate, Utilities.PRESTAMO, prestamo.Descripcion));
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
        /// Se elimina un Prestamo por IdPrestamo
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns>Eliminar un Prestamo por IdPrestamo</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al actualizar un Prestamo.</response>
        // DELETE api/<PrestamoController>/5
        [HttpDelete("{idPrestamo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Delete(int idPrestamo)
        {
            try
            {
                _ = await _prestamoBusiness.DeletePrestamoAsync(idPrestamo);
                return StatusCode(StatusCodes.Status200OK,
                    string.Format(Resource.SuccessfulDelete, idPrestamo));
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
