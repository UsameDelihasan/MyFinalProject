﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUIIII
{

    //SOLID 
    // (O)pen Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //IoC

        }

        //    static void CategoryTest()
        //    {
        //        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //        foreach (var category in categoryManager.GetAll())
        //        {
        //            Console.WriteLine(category.CategoryName + '/' + category.CategoryName);
        //        }
        //    }

        //    static void ProductTest()
        //    {
        //        ProductManager productManager = new ProductManager(new EfProductDal());

        //        var result = productManager.GetProductDetailDtos();
        //        if (result.Success == true)
        //        {
        //            foreach (var item in result.Data)
        //            {
        //                Console.WriteLine(item.ProductName + "/" + item.CategoryName);
        //            }
        //        }

        //        else
        //        {
        //            Console.WriteLine(result.Message);
        //        }
        //    }
    }
}
