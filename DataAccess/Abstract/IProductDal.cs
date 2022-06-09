using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    //veritabanında yapacağım operasyonlarla ilgili
    public interface IProductDal : IEntityRepository<Product>
    {
        

    }
}
