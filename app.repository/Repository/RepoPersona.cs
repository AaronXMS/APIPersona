using app.domain;
using app.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace app.repository.Repository
{
    public class RepoPersona: IRepoPersona
    {
        private readonly PersonaContext context;
        public IConfiguration Configuration { get; }
        public RepoPersona(PersonaContext context, IConfiguration configuration)
        {
            this.context = context;
            Configuration = configuration;
        }

        public async Task<List<Persona>> GetListAsync(string? filter)
        {
            var query = context.Persona.OrderBy(r => r.Id).AsQueryable();
            if (filter != null)
            {
                

                bool isNumeric = int.TryParse(filter, out int n);
                if (isNumeric)
                {
                    query = query.Where(s => s.Edad == n);
                }
                else
                {
                    query = query.Where(s => s.Nombre.Contains(filter) || s.Apellido.Contains(filter));
                    //query = query.Where(s => s.Apellido.Contains(filter));
                }
            }

            return await query.ToListAsync();
        }

        public async Task PostAsync(Persona persona)
        {
            await context.Persona.AddAsync(persona);
            await context.SaveChangesAsync();
        }

        public async Task PutAsync(Persona persona)
        {
            context.Entry(persona).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var persona = await context.Persona.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (persona != null)
            {
                context.Persona.Remove(persona);
                await context.SaveChangesAsync();
            }
        }
    }
}