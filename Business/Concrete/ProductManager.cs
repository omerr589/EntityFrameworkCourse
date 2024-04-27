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
            // Business Rules
            // Permissions
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime); // At 22, we don't want to List data's
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProcutsListed);
        }

        public IDataResult<List<Product>> GetAllByProductId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProcutsListed);

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max), Messages.ProcutsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime); // At 21, we don't want to List data's
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}