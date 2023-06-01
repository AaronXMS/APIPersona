using app.domain;
using app.repository.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.repository.UOW
{
    public class PersonaUOW: IPersonaUOW
    {
        readonly PersonaContext context;
        public IRepoPersona RepoPersona { get; set; }

        public PersonaUOW(IConfiguration configuration)
        {
            context = new PersonaContext();
            RepoPersona = new RepoPersona(this.context, configuration);
        }
    }
}
