using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class DeparmentService
    {
        private readonly WebApplication2Context _context;
        public DeparmentService(WebApplication2Context context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
