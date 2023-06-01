using app.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.repository.Repository
{
    public interface IRepoPersona
    {
        Task DeleteAsync(Guid id);
        Task<List<Persona>> GetListAsync(string? filter);
        Task PostAsync(Persona persona);
        Task PutAsync(Persona persona);
    }
}
