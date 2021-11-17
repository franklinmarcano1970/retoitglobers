using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
    /// Clase para el manejo de los servicios ApiRest de la entidad Editoriales
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EditorialController : BaseController
    {

        private readonly ILogger<EditorialController> _logger;
        private readonly IEditorialService _editorialService;
        private readonly IMemoryCache _memoryCache;
        private readonly string editorialtKey = "editorialKey";
        public EditorialController(ILogger<EditorialController> logger, IEditorialService editorialService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _editorialService = editorialService;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Servicio que devuelve una instancia del modelo de Editoriales
        /// </summary>
        /// <returns><EditorialDto></returns>
        [HttpGet]
        public async Task<ActionResult<EditorialDto>> GetEditorailById(int id)
        {
            try
            {
                return await _editorialService.GetEditorialByIdAsync(id);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que devuelve todos los registros del modelo de Editoriales
        /// </summary>
        /// <returns>IEnumerable<EditorialDto></returns>
        [HttpGet]
        public ActionResult<IEnumerable<EditorialDto>> GetAllEditorial()
        {
            try
            {
                IEnumerable<EditorialDto> editorialDtoCollection = null;
                // Verificamos si existe cache
                if (_memoryCache.TryGetValue(editorialtKey, out editorialDtoCollection))
                {
                    return Ok(editorialDtoCollection);
                }
                editorialDtoCollection = _editorialService.GetAllEditorialAsync();

                // Configuramos el cache con una expiracion de 30 segundos
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));

                // configuramos el cache al objeto de datos
                _memoryCache.Set(editorialtKey, editorialDtoCollection, cacheOptions);

                return Ok(editorialDtoCollection);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que agrega una instancia al modelo de Editoriales
        /// </summary>
        /// <param name="EditorialDto"></param>
        /// <returns>IEnumerable<ResponseDto></returns>
        [HttpPost]
        public async Task<ActionResult<EditorialDto>> AddEditorialAsync(EditorialDto EditorialDto)
        {
            try
            {
                return await _editorialService.AddEditorialAsync(EditorialDto);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        /// <summary>
        /// Servicio que modifica una instancia al modelo de Editoriales
        /// </summary>
        /// <param name="EditorialDto"></param>
        /// <returns>IEnumerable<ResponseDto></returns>
        [HttpPut]
        public async Task<ActionResult<EditorialDto>> UpdateEditorialAsync(EditorialDto EditorialDto)
        {
            try
            {
                return await _editorialService.UpdateEditorialAsync(EditorialDto);
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
