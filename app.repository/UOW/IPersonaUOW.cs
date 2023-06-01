using app.repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.repository.UOW
{
    public interface IPersonaUOW
    {
        IRepoPersona RepoPersona { get; set; }
    }
}
