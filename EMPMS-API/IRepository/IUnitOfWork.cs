
using EMPMS_API.Data.Employee;

namespace EMPMS_API.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<EmployeeData> Employees { get; }
        Task Save();
    }
}
