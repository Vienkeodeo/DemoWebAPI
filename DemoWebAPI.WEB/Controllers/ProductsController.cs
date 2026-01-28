using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoWebAPI.DB.Model;
using DemoWebAPI.DB.Models;
using DemoWebAPI.DB.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DemoWebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var list = await _productRepository.GetAllProduct();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product =await _productRepository.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                await _productRepository.UpdateProduct(id, product);
                return Ok( );
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepository.CreateProduct(product);
                return Ok();
            }
            return BadRequest();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            await _productRepository.DeleteProduct(id);
            return Ok();
        }
    }
}
