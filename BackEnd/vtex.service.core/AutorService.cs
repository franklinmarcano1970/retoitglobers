using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vtex.dto.core;
using vtex.repository.core;

namespace vtex.service.core
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _AutorRepository;

        public AutorService(IAutorRepository AutorRepository)
        {
            _AutorRepository = AutorRepository;
        }

        public async Task<AutorDto> AddAutorAsync(AutorDto Autor)
        {
            var _Autor = await _AutorRepository.AddAsync(new context.core.Models.Autor
            {
                Apellidos = Autor.Apellidos,
                Nombre = Autor.Nombre
            });
            return new AutorDto { 
                Id = _Autor.Id,
                Nombre = _Autor.Nombre,
                Apellidos = _Autor.Apellidos,
            };
        }

        public List<AutorDto> GetAllAutorAsync()
        {
            var _Autors = _AutorRepository.GetAll();
            List<AutorDto> _AutorsDto = new List<AutorDto>();
            foreach (var item in _Autors)
            {
                _AutorsDto.Add(new AutorDto
                {
                    Id = item.Id,
                    Apellidos = item.Apellidos,
                    Nombre = item.Nombre
                });
            }
            return _AutorsDto;
        }

        public async Task<AutorDto> GetAutorByIdAsync(int id)
        {
            var _Autor = await _AutorRepository.GetAutorByIdAsync(id);
            return new AutorDto
            {
                Id = _Autor.Id,
                Nombre = _Autor.Nombre,
                Apellidos = _Autor.Apellidos
            };
        }

        public async Task<AutorDto> UpdateAutorAsync(AutorDto Autor)
        {
            var _Autor = await _AutorRepository.GetAutorByIdAsync(Autor.Id);
            _Autor.Nombre = Autor.Nombre;
            _Autor.Apellidos = Autor.Apellidos;
            var _AutorSave = await _AutorRepository.UpdateAsync(_Autor);
            return new AutorDto
            {
                Id = _AutorSave.Id,
                Nombre = _AutorSave.Nombre,
                Apellidos = _AutorSave.Apellidos,
            };
        }
    }
}
