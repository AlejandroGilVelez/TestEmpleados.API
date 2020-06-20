using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpleados.DataModel
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> ObtenerPorEmail(string email);
    }
}
