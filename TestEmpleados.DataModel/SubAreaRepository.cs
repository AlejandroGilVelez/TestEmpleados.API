using Framework.Data;
using Framework.Models;

namespace TestEmpleados.DataModel
{
    public class SubAreaRepository : GenericRepository<SubArea>, ISubAreaRepository
    {
        public SubAreaRepository(DataContext context) : base(context)
        {
        }
    }
}
