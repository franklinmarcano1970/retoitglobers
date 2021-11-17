using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using vtex.dto.core;
using vtex.repository.core;

namespace vtex.service.core
{
    public class AutorLibroService : ILibroAutorService
    {
        private readonly ILibroAutorRepository _AutorRepository;

        public AutorLibroService(ILibroAutorRepository AutorRepository)
        {
            _AutorRepository = AutorRepository;
        }

        public async Task<AutoresHasLibroDto> AddAutorLibroAsync(AutoresHasLibroDto Autor)
        {
            var _Autor = await _AutorRepository.AddAsync(new context.core.Models.AutoresHasLibro
            {
                AutoresId = Autor.AutoresId,
                LibrosIsbn = Autor.LibrosIsbn
            });
            return new AutoresHasLibroDto
            { 
                AutoresId = _Autor.AutoresId,
                LibrosIsbn = _Autor.LibrosIsbn
            };
        }


        public List<AutoresHasLibroDto> GetAllAutorLibroAsync()
        {
            var _Autors = _AutorRepository.GetAll();
            List<AutoresHasLibroDto> _AutorsDto = new List<AutoresHasLibroDto>();
            foreach (var item in _Autors)
            {
                _AutorsDto.Add(new AutoresHasLibroDto
                {
                    AutoresId = item.AutoresId,
                    LibrosIsbn = item.LibrosIsbn
                });
            }
            return _AutorsDto;
        }

        public async Task<AutoresHasLibroDto> GetAutorLibroByIdAsync(int id, int isbn)
        {
            var _Autor =  _AutorRepository.GetAll().ToList().Where(x=>x.AutoresId == id && x.LibrosIsbn == isbn).FirstOrDefault();
            return new AutoresHasLibroDto
            {
                LibrosIsbn = _Autor.LibrosIsbn,
                AutoresId = _Autor.AutoresId
            };
        }

        public async Task<AutoresHasLibroDto> GetLibroByIdAsync(int id)
        {
            var _Autor = await _AutorRepository.GetLibroByIdAsync(id);
            return new AutoresHasLibroDto
            {
                LibrosIsbn = _Autor.LibrosIsbn,
                AutoresId = _Autor.AutoresId
            };
        }


        public async Task<AutoresHasLibroDto> GetAutorByIdAsync(int id)
        {
            var _Autor = await _AutorRepository.GetAutorByIdAsync(id);
            return new AutoresHasLibroDto
            {
                LibrosIsbn = _Autor.LibrosIsbn,
                AutoresId = _Autor.AutoresId
            };
        }

    }
}
