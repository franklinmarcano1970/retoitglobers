using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vtex.dto.core;

namespace vtex.service.core
{
    public interface IEditorialService
    {
        Task<EditorialDto> AddEditorialAsync(EditorialDto Editorial);
        Task<EditorialDto> UpdateEditorialAsync(EditorialDto Editorial);
        List<EditorialDto> GetAllEditorialAsync();
        Task<EditorialDto>GetEditorialByIdAsync(int id);
    }
}
