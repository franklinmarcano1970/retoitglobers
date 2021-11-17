using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using vtex.dto.core;
using vtex.service.core;

namespace vtex.api.core.Controllers
{
    /// <summary>
    /// Clase para el manejo de los servicios ApiRest de la entidad Autores
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AutorController : BaseController
    {

        private readonly ILogger<AutorController> _logger;
        private readonly IAutorService _autorService;

        public AutorController(ILogger<AutorController> logger, IAutorService autorService)
        {
            _logger = logger;
            _autorService = autorService;
        }

        /// <summary>
        /// Servicio que devuelve una instancia del modelo de Autores
        /// </summary>
        /// <returns><AutorDto></returns>
        [HttpGet]
        public async Task<ActionResult<AutorDto>> GetAutorById(int id)
        {
            try
            {
                return await _autorService.GetAutorByIdAsync(id);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que devuelve todos los registros del modelo de Autores
        /// </summary>
        /// <returns>IEnumerable<AutorDto></returns>
        [HttpGet]
        public ActionResult<IEnumerable<AutorDto>> GetAllAutor()
        {
            try
            {
                return _autorService.GetAllAutorAsync();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que agrega una instancia al modelo de autores
        /// </summary>
        /// <param name="autorDto"></param>
        /// <returns>IEnumerable<ResponseDto></returns>
        [HttpPost]
        public async Task<ActionResult<AutorDto>> AddAutorAsync(AutorDto autorDto)
        {
            try
            {
                return await _autorService.AddAutorAsync(autorDto);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que modifica una instancia al modelo de autores
        /// </summary>
        /// <param name="autorDto"></param>
        /// <returns>IEnumerable<ResponseDto></returns>
        [HttpPut]
        public async Task<ActionResult<AutorDto>> UpdateAutorAsync(AutorDto autorDto)
        {
            try
            {
                return await _autorService.UpdateAutorAsync(autorDto);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private ObjectResult HandleException(Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }

    }
}
