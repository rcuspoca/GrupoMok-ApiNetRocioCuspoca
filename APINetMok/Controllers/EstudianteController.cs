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


    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteBusiness _estudianteBusiness;

        public EstudianteController(IEstudianteBusiness estudianteBusiness)
        {
            _estudianteBusiness = estudianteBusiness;
        }
        /// <summary>
        /// Obtiene el listado de estudiantes
        /// </summary>
        /// <returns>Listado de empleados</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al consultar estudiantes.</response>
   
        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EstudianteDto>>> Get([FromQuery] PaginacionDto paginacionDto)
        {
            try
            {
                return Ok(await _estudianteBusiness.GetEstudianteAsync());
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
        /// Se crea un estudiante
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns>Creación de un estudiante</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al crear un estudiante.</response>

        // POST api/<EstudianteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Post([FromBody] EstudianteDto estudiante)
        {
            try
            {
                _ = await _estudianteBusiness.AddEstudianteAsync(estudiante);
                return StatusCode(StatusCodes.Status201Created,
                    string.Format(Resource.SuccessfulCreation, Utilities.ESTUDIANTE, estudiante.Nombres +" "+ estudiante.Apellidos));
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

        // PUT api/<EstudianteController>/5
        /// <summary>
        /// Se actualiza el registro de un estudiante seleccionado
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns>Actualización del registro de un estudiante</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al actualizar un estudiante.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Put([FromBody] EstudianteDto estudiante)
        {
            try
            {
                _ = await _estudianteBusiness.UpdateEstudianteAsync(estudiante);
                return StatusCode(StatusCodes.Status201Created,
                    string.Format(Resource.SuccessfulUpdate, Utilities.ESTUDIANTE, estudiante.Nombres + " "+ estudiante.Apellidos));
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
        /// Se elimina un estudiante por IdEstudiante
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns>Eliminar un estudiante por IdEstudiante</returns>
        /// <response code="200">Operación finalizada exitosamente.</response>
        /// <response code="400">Se presentó un error de validación de datos.</response>
        /// <response code="500">Se presentó un error interno al actualizar un estudiante.</response>
        // DELETE api/<EstudianteController>/5
        [HttpDelete("{idEstudiante}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> Delete(int idEstudiante)
        {
            try
            {
                _ = await _estudianteBusiness.DeleteEstudianteAsync(idEstudiante);
                return StatusCode(StatusCodes.Status200OK,
                    string.Format(Resource.SuccessfulDelete, idEstudiante));
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
