using Microsoft.Extensions.Logging;
using SGP.Application.Interfaces;
using SGP.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGP.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<OperationResult> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
