using Microsoft.EntityFrameworkCore;
using SalesSystemTest.Data;
using SalesSystemTest.Models;

namespace SalesSystemTest.Services
{
    public class DepartmentService
    {
        private readonly SalesSystemTestContext _context;

        public DepartmentService(SalesSystemTestContext context)
        {
            _context = context;
        }


        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
