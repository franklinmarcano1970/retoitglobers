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
    public class AutorLibroController : BaseController
    {

        private readonly ILogger<AutorLibroController> _logger;
        private readonly ILibroAutorService _autorService;

        public AutorLibroController(ILogger<AutorLibroController> logger, ILibroAutorService autorService)
        {
            _logger = logger;
            _autorService = autorService;
        }

        /// <summary>
        /// Servicio que devuelve una instancia del modelo de Autores y libros
        /// </summary>
        /// <returns><AutoresHasLibroDto></returns>
        [HttpGet]
        public async Task<ActionResult<AutoresHasLibroDto>> GetLibroById(int isbn)
        {
            try
            {
                return await _autorService.GetLibroByIdAsync(isbn);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que devuelve una instancia del modelo de Autores y libros
        /// </summary>
        /// <returns><AutoresHasLibroDto></returns>
        [HttpGet]
        public async Task<ActionResult<AutoresHasLibroDto>> GetAutorById(int id)
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
        /// Servicio que devuelve todos los registros del modelo de Autores y libros
        /// </summary>
        /// <returns><AutorDto></returns>
        [HttpGet]
        public async Task<ActionResult<AutoresHasLibroDto>> GetLibroAutorById(int id, int isbn)
        {
            try
            {
                return await _autorService.GetAutorLibroByIdAsync(id, isbn);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que agrega una instancia al modelo de autores y libros
        /// </summary>
        /// <param name="autorDto"></param>
        /// <returns>IEnumerable<ResponseDto></returns>
        [HttpPost]
        public async Task<ActionResult<AutoresHasLibroDto>> AddAutorAsync(AutoresHasLibroDto autorDto)
        {
            try
            {
                return await _autorService.AddAutorLibroAsync(autorDto);
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
