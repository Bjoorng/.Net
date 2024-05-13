using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.Domain.DTOs.ProductDTOs;
using Storage.Domain.Infrastructure.Data;
using Storage.Domain.Models;

namespace Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductListDTO>> GetProducts()
        {
            var products = _context.Products.ProjectTo<ProductListDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{sku}")]
        public ActionResult<Product> GetProduct(string sku)
        {

            var product = _context.Products.FirstOrDefault(p => p.Sku == sku);

            if (product == null)
            {
                return NotFound();
            }

            ProductDetailsDTO pDetailsDto = _mapper.Map<ProductDetailsDTO>(product);
            return Ok(pDetailsDto);

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{sku}")]
        public IActionResult PutProduct(string sku, ProductUpdateQuantityDTO productDTO)
        {
            var product = _context.Products.FirstOrDefault(p => p.Sku == sku);

            try
            {
                product.UpdateQuantity(productDTO.Quantity);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(sku))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(product);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Product> PostProduct(ProductCreateDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{sku}")]
        public IActionResult DeleteProduct(string sku)
        {
            var product = _context.Products.FirstOrDefault(p => p.Sku == sku);
            if (!ProductExists(sku))
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChangesAsync();

            return Ok();
        }

        private bool ProductExists(string sku)
        {
            return _context.Products.Any(e => e.Sku == sku);
        }
    }
}
