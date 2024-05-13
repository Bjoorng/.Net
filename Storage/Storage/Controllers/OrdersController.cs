using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.Domain.Infrastructure.Data;
using Storage.Domain.Models;

namespace Storage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Guid id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Order> PostOrder(OrderCreateDTO orderCreateDTO)
        {
            List<OrderItem> items = new();
            orderCreateDTO.Products.ForEach(e =>
            {
                Product p = _context.Products.FirstOrDefault(p => p.Sku == e.Sku);
                if (p.Quantity > e.Quantity)
                {
                    items.Add(OrderItem.Create(p, e.Quantity));
                    p.UpdateQuantityOrder(e.Quantity);
                    _context.Update(p);
                }
            });
            Order o = Order.Create(items);
            if (o != null)
            {
                _context.Orders.Add(o);
            }
            _context.SaveChanges();

            return Ok(o);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (!OrderExists(id))
            {
                return NotFound();
            }
            List<OrderItem> items = _context.OrderItems.Where(item => item.Id == order.Id).ToList();
            items.ForEach(item =>
            {
                Product p = _context.Products.FirstOrDefault(product => product.Sku == item.Product.Sku);
                p.UpdateQuantityDelete(item.Quantity);
                _context.Products.Update(p);
            });
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return Ok();
        }

        private bool OrderExists(Guid id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
