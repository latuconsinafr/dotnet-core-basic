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
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product product = await _productRepository.Get(id);
            if(product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new()
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                DateCreated = DateTime.Now
            };

            await _productRepository.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            Product product = new()
            {
                ProductId = id,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
                DateUpdated = DateTime.Now
            };

            await _productRepository.Update(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product product = await _productRepository.Get(id);
            if(product == null)
                return NotFound();

            await _productRepository.Delete(id);
            return Ok(product);
        }
    }
}