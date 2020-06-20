using Framework.Data;
using Framework.Models;

namespace TestEmpleados.DataModel
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(DataContext context) : base(context)
        {
        }
    }
}
