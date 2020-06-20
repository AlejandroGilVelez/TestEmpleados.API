using Framework.Data;
using Framework.Models;

namespace TestEmpleados.DataModel
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(DataContext context) : base(context)
        {
        }
    }
}
