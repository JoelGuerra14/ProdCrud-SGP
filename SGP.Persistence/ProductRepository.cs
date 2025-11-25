using Microsoft.Extensions.Logging;
using SGP.Persistence.Db;

namespace SGP.Persistence
{
    public class ProductRepository
    {
        private readonly Context _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(Context context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }   
    }
}
