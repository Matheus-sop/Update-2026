using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class SellerService
    {
        private readonly WebApplication2Context _context;
        public SellerService(WebApplication2Context context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
