using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Appslx.Repository.Products;
using Appslx.Service.Base;

namespace Appslx.Service.Products
{
    public interface IProductService:IEntityService<Product>
    {
        Product GetById(int id);
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
    }
}
