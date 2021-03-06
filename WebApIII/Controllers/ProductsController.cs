using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        //Loosely Coupled
        //IoC Container -- Inversion Of Control 
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //swagger
            //dependency chain --
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }








        [HttpPost("post")]
        public IActionResult Post(Product product)
        {

            var result = _productService.Add(product);

            if (result.Success)
            {

                return Ok(result);

            }
            return BadRequest(result);

        }







        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        // {
        //    var result = _productService.GetById(id);

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}
    }
}
