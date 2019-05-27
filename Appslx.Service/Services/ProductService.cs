using System.Linq;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Appslx.Repository.Products;
using Appslx.Service.Base;

namespace Appslx.Service.Services
{
    public interface IProductService:IEntityService<Product>
    {
        Product GetById(int id);
        IQueryable<Product> GetProductsForPagination();
        Product GetByCode(string code);
        Product CreateNew();
    }
    public class ProductService:EntityService<Product>,IProductService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public ProductService(IUnitOfWork unitOfWork,IProductRepository productRepository) : base(unitOfWork, productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IQueryable<Product> GetProductsForPagination()
        {
            return _productRepository.GetForPagination();
        }

        public Product GetByCode(string code)
        {
            return _productRepository.GetAll().FirstOrDefault(x => x.Code.ToLower() == code.ToLower());
        }

        public Product CreateNew()
        {
            return new Product { Code = GenerateCode(), };
        }

        private string GenerateCode()
        {
            return "PR" + (_productRepository.GetCount() + 1).ToString("0000#");
        }
    }
}
