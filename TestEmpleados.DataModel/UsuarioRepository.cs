using Framework.Data;
using Framework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpleados.DataModel
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private new readonly DataContext context;
        public UsuarioRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Usuario> ObtenerPorEmail(string email)
        {
            return await context.Usuarios.FirstOrDefaultAsync(x => x.Activo && x.Email.ToLower() == email.ToLower());
        }
    }
}
