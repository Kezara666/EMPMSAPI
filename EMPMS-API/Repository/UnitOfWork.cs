using EMPMS_API.Data;
using EMPMS_API.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Employee.Data;
using EMPMS_API.Data.Employee;

namespace EMPMS_API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EMSContext _context;

        private IGenericRepository<EmployeeData> _employee;
        public UnitOfWork(EMSContext context)
        {
            _context = context;
        }

        public IGenericRepository<EmployeeData> Employees => _employee ??= new GenericRepository<EmployeeData>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
