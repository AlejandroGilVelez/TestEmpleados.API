using Framework.Data;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestEmpleados.DataModel
{
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private new readonly DataContext context;
        public EmpleadoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
