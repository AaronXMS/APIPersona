using app.domain.Entities;
using app.domain.VM;
using app.repository.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.logic
{
    public class PersonaLogic
    {
        private readonly IPersonaUOW ouw;

        public PersonaLogic(IPersonaUOW ouw)
        {
            this.ouw = ouw;
        }

        public async Task<List<Persona>> GetAsync(string? filter)
        {
            var res = await ouw.RepoPersona.GetListAsync(filter);
            return res;
        }

        public async Task PostAsync(PersonaVM persona)
        {
            var entity = new Persona();
            entity.Nombre = persona.Nombre; 
            entity.Apellido= persona.Apellido;
            entity.Edad=    persona.Edad;   
            await ouw.RepoPersona.PostAsync(entity);
        }

        public async Task PutAsync(Persona persona)
        {
            await ouw.RepoPersona.PutAsync(persona);
        }

        public async Task DeleteAsync(Guid id)
        {
            await ouw.RepoPersona.DeleteAsync(id);
        }
    }
}
