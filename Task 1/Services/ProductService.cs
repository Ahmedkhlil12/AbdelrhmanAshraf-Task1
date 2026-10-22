using Task_1.DTOs;
using Task_1.Models;

namespace Task_1.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products =
        [
            new Product { Id = 1, Name = "Laptop", Price = 15000m, Stock = 10, Description = "Gaming laptop" },
            new Product { Id = 2, Name = "Mouse", Price = 250m, Stock = 50, Description = "Wireless mouse" },
            new Product { Id = 3, Name = "Keyboard", Price = 500m, Stock = 30, Description = "Mechanical keyboard" }
        ];

        private int _nextId = 4;

        public IEnumerable<ProductV1Dto> GetAllV1()
        {
            return _products.Select(MapToV1).ToList();
        }

        public ProductV1Dto? GetByIdV1(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product is null ? null : MapToV1(product);
        }

        public IEnumerable<ProductV2Dto> GetAllV2()
        {
            return _products.Select(MapToV2).ToList();
        }

        public ProductV2Dto? GetByIdV2(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return product is null ? null : MapToV2(product);
        }

        public ProductV2Dto Create(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = _nextId++,
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                Description = dto.Description
            };

            _products.Add(product);
            return MapToV2(product);
        }

        private static ProductV1Dto MapToV1(Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        private static ProductV2Dto MapToV2(Product product) => new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description
        };
    }
}
