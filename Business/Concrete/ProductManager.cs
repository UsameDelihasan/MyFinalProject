using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.CCS;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        //validation bir Cross Cutting Concern ' dir




        /* Encryption --> key ile kilitlersiniz
          
         ,
         
          
         Hashing --> MD5 , SHA1 gibi şifreleme algoritmaları vasıtasıyla geri dönüşü olmayacak şekilde şifrelerler
        
               kendimiz şifreyi daha sağlam hale getirmek için. "salting" yaparak kullacının yazdığı şifreye eklenti yapıyoruz 
         
         */


        //claim
        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result  = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
            CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded()) ;


            if (result != null)
            {
                _productDal.Add(product);

                return new SuccessResult(Messages.ProductAdded);
            }
     
            return new ErrorResult();
            //---Eski-- -

            //if (pet.Name.Length > 1)
            //{
            //    _petDal.Add(pet);

            //    return new SuccessResult(Messages.AddPetSuccess);
            //}
            //return new ErrorResult(Messages.AddPetError);

            
        }

        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //iş kodları
            //yetkisi var mı?
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
            
        }




        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId ==id));
        }




        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.UnitPrice>min && p.UnitPrice<max));
        }




        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId ));
        }




        public IDataResult<List<ProductDetailDto>> GetProductDetailDtos()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos());
        }




        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;

            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {

            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new ErrorResult();

        }

    }
}
