using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vtex.dto.core;
using vtex.repository.core;

namespace vtex.service.core
{
    public class LibroService:ILibroService
    {
        private readonly ILibroRepository _libroRepository;

        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public async Task<LibroDto> AddLibroAsync(LibroDto libro)
        {
            var _libro = await _libroRepository.AddAsync(new context.core.Models.Libro
            {
                Titulo = libro.Titulo,
                EditorialesId = libro.EditorialesId,
                Isbn = libro.Isbn,
                NPaginas = libro.NPaginas,
                Sinopsis = libro.Sinopsis
            });
            return new LibroDto { 
                Isbn = _libro.Isbn,
                EditorialesId = _libro.EditorialesId,
                Sinopsis = _libro.Sinopsis,
                NPaginas = _libro.NPaginas,
                Titulo = _libro.Titulo
            };
        }

        public List<LibroDto> GetAllLibroAsync()
        {
            var _libros = _libroRepository.GetAll();
            List<LibroDto> _librosDto = new List<LibroDto>();
            foreach (var item in _libros)
            {
                _librosDto.Add(new LibroDto
                {
                    Isbn = item.Isbn,
                    EditorialesId = item.EditorialesId,
                    NPaginas = item.NPaginas,
                    Sinopsis = item.Sinopsis,
                    Titulo = item.Titulo
                });
            }
            return _librosDto;
        }

        public async Task<LibroDto> GetLibroByIdAsync(int id)
        {
            var _libro = await _libroRepository.GetLibroByIdAsync(id);
            return new LibroDto
            {
                Isbn = _libro.Isbn,
                Titulo = _libro.Titulo,
                EditorialesId = _libro.EditorialesId,
                NPaginas = _libro.NPaginas,
                Sinopsis = _libro.Sinopsis
            };
        }

        public async Task<LibroDto> UpdateLibroAsync(LibroDto libro)
        {
            var _libro = await _libroRepository.GetLibroByIdAsync(libro.Isbn);
            _libro.NPaginas = libro.NPaginas;
            _libro.Sinopsis = libro.Sinopsis;
            _libro.Titulo = libro.Titulo;
            var _libroSave = await _libroRepository.UpdateAsync(_libro);
            return new LibroDto
            {
                Isbn = _libroSave.Isbn,
                EditorialesId = _libroSave.EditorialesId,
                Sinopsis = _libroSave.Sinopsis,
                NPaginas = _libroSave.NPaginas,
                Titulo = _libroSave.Titulo
            };
        }
    }
}
