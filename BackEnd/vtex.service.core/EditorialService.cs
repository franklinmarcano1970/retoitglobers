using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vtex.dto.core;
using vtex.repository.core;

namespace vtex.service.core
{
    public class EditorialService : IEditorialService
    {
        private readonly IEditorialRepository _EditorialRepository;

        public EditorialService(IEditorialRepository EditorialRepository)
        {
            _EditorialRepository = EditorialRepository;
        }

        public async Task<EditorialDto> AddEditorialAsync(EditorialDto Editorial)
        {
            var _Editorial = await _EditorialRepository.AddAsync(new context.core.Models.Editorial
            {
                Nombre = Editorial.Nombre,
                Sede = Editorial.Sede
            });
            return new EditorialDto { 
                Id = _Editorial.Id,
                Nombre = _Editorial.Nombre,
                Sede = _Editorial.Sede,
            };
        }

        public List<EditorialDto> GetAllEditorialAsync()
        {
            var _Editorials = _EditorialRepository.GetAll();
            List<EditorialDto> _EditorialsDto = new List<EditorialDto>();
            foreach (var item in _Editorials)
            {
                _EditorialsDto.Add(new EditorialDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Sede = item.Sede
                });
            }
            return _EditorialsDto;
        }

        public async Task<EditorialDto> GetEditorialByIdAsync(int id)
        {
            var _Editorial = await _EditorialRepository.GetEditorialByIdAsync(id);
            return new EditorialDto
            {
                Id = _Editorial.Id,
                Nombre = _Editorial.Nombre,
                Sede = _Editorial.Sede
            };
        }

        public async Task<EditorialDto> UpdateEditorialAsync(EditorialDto Editorial)
        {
            var _Editorial = await _EditorialRepository.GetEditorialByIdAsync(Editorial.Id);
            _Editorial.Nombre = Editorial.Nombre;
            _Editorial.Sede = Editorial.Sede;
            var _EditorialSave = await _EditorialRepository.UpdateAsync(_Editorial);
            return new EditorialDto
            {
                Id = _EditorialSave.Id,
                Nombre = _EditorialSave.Nombre,
                Sede = _EditorialSave.Sede,
            };
        }
    }
}
