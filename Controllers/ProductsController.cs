using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_basic.Dto;
using dotnet_basic.Models;
using dotnet_basic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_basic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseRepository<Product> productRepository;

        public ProductsController(IBaseRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await this.productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            Product product = await this.productRepository.GetById(id);
            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            await this.productRepository.Add(product);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, Product product)
        {
            await this.productRepository.Update(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            Product product = await this.productRepository.GetById(id);
            if(product == null)
                return NotFound();

            await this.productRepository.Remove(id);
            return Ok();
        }
    }
}