using Framework.Data;
using Framework.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestEmpleados.DataModel
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        
        public UsuarioRepository(DataContext context) : base(context)
        {
        }

        public async Task<Usuario> ObtenerPorEmail(string email)
        {
            return await context.Set<Usuario>().FirstOrDefaultAsync(x => x.Activo && x.Email.ToLower() == email.ToLower());
        }
    }
}
