using Task_1.DTOs;

namespace Task_1.Services
{
    public interface IProductService
    {
        IEnumerable<ProductV1Dto> GetAllV1();
        ProductV1Dto? GetByIdV1(int id);
        IEnumerable<ProductV2Dto> GetAllV2();
        ProductV2Dto? GetByIdV2(int id);
        ProductV2Dto Create(CreateProductDto dto);
    }
}
