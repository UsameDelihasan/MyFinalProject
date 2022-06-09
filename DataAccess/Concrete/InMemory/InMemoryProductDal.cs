﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{

    
    public class InMemoryProductDal : IProductDal 
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>() {

            new Product{Id=1,CategoryId=1,ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
            new Product{Id=2,CategoryId=1,ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
            new Product{Id=3,CategoryId=2,ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
            new Product{Id=4,CategoryId=2,ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
            new Product{Id=5,CategoryId=2,ProductName="Fare", UnitPrice=85, UnitsInStock=1}


            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            Product productToDelete;

            product = _products.SingleOrDefault(p=>p.Id == product.Id);

            //Long way of LINQ (Language Integration Query)
            //Product tempProduct=null;

            //foreach (var p in _products)
            //{
            //    if (product.Id == p.Id)
            //    {
            //        tempProduct = product;

            //    }   
            //}

            //_products.Remove(product);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {

            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {

            Product productToUpdate = null;
            productToUpdate = _products.SingleOrDefault(p=>p.Id == product.Id);

            productToUpdate.Id = product.Id;
            productToUpdate.ProductName = product.ProductName; 

            //Product productToUpdate=null;

            //foreach (var p in _products)
            //{
            //    if ( p.Id == product.Id)
            //    {
            //        productToUpdate = p;
            //    }
            //}

            //productToUpdate.ProductName = product.ProductName;
            //productToUpdate.Id = product.Id; ...
        }
    }
}
