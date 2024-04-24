using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            // Business Rules
            if (product.ProductName.Length < 2)
                return new ErrorResult(Messages.ProductNameInvalid);

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAddedMessage);
            // return new SuccessResult(); // without message
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(_productDal.GetAll()); // At 22, we don't want to List data's
            }
            // Business Rules
            // Permissions
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Ürünler Listelendi");
        }

        public List<Product> GetAllByProductId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}