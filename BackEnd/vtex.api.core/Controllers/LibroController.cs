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
    /// Clase para el manejo de los servicios ApiRest de la entidad Libroes
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LibroController : BaseController
    {

        private readonly ILogger<LibroController> _logger;
        private readonly ILibroService _libroService;

        public LibroController(ILogger<LibroController> logger, ILibroService libroService)
        {
            _logger = logger;
            _libroService = libroService;
        }

        /// <summary>
        /// Servicio que devuelve una instancia del modelo de Libroes
        /// </summary>
        /// <returns><LibroDto></returns>
        [HttpGet]
        public async Task<ActionResult<LibroDto>> GetLibroById(int isbn)
        {
            try
            {
                return await _libroService.GetLibroByIdAsync(isbn);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que devuelve todos los registros del modelo de Libroes
        /// </summary>
        /// <returns>IEnumerable<LibroDto></returns>
        [HttpGet]
        public ActionResult<IEnumerable<LibroDto>> GetAllLibro()
        {
            try
            {
                return _libroService.GetAllLibroAsync();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que agrega una instancia al modelo de Libroes
        /// </summary>
        /// <param name="LibroDto"></param>
        /// <returns>IEnumerable<ResponseDto></returns>
        [HttpPost]
        public async Task<ActionResult<LibroDto>> AddLibroAsync(LibroDto LibroDto)
        {
            try
            {
                return await _libroService.AddLibroAsync(LibroDto);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que modifica una instancia al modelo de Libroes
        /// </summary>
        /// <param name="LibroDto"></param>
        /// <returns>IEnumerable<ResponseDto></returns>
        [HttpPut]
        public async Task<ActionResult<LibroDto>> UpdateLibroAsync(LibroDto LibroDto)
        {
            try
            {
                return await _libroService.UpdateLibroAsync(LibroDto);
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
