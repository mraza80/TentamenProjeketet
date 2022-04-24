#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TentamenProjeketet.Filter;
using TentamenProjeketet.Models.Data;
using TentamenProjeketet.Models.Entities;

namespace TentamenProjeketet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductEntities
        [HttpGet]
        [Userapikey]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/ProductEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            return productEntity;
        }

        // PUT: api/ProductEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Useradminapikey]
        public async Task<IActionResult> PutProductEntity(int id, ProductEntity productEntity)
        {
            if (id != productEntity.artikelnummer)
            {
                return BadRequest();
            }

            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
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

        // POST: api/ProductEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Useradminapikey]
        public async Task<ActionResult<ProductEntity>> PostProductEntity(ProductEntity productEntity)
        {
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductEntity", new { id = productEntity.artikelnummer }, productEntity);
        }

        // DELETE: api/ProductEntities/5
        [HttpDelete("{id}")]
        [Useradminapikey]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.Products.Any(e => e.artikelnummer == id);
        }
    }
}
