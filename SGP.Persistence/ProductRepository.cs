using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SGP.Application.Interfaces;
using SGP.Domain.Base;
using SGP.Persistence.Db;

namespace SGP.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(Context context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OperationResult> GetAllAsync()
        {
            try
            {
                var products = await _context.Products
                                             .Where(p => !p.IsDeleted)
                                             .AsNoTracking()
                                             .ToListAsync();
                return OperationResult.Success("Productos obtenidos", products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en GetAllAsync");
                return OperationResult.Failure($"Error: {ex.Message}");
            }
        }

        public async Task<OperationResult> GetByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null || product.IsDeleted)
                    return OperationResult.Failure("Producto no encontrado");

                return OperationResult.Success("Producto encontrado", product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error en GetByIdAsync {id}");
                return OperationResult.Failure($"Error: {ex.Message}");
            }
        }
    }
}
