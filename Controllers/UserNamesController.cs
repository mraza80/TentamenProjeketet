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
    public class UserNamesController : ControllerBase
    {
        private readonly DataContext _context;

        public UserNamesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserNames
        [HttpGet]
        [Userapikey]
        public async Task<ActionResult<IEnumerable<UserName>>> GetUserNames()
        {
            return await _context.UserNames.ToListAsync();
        }

        // GET: api/UserNames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserName>> GetUserName(int id)
        {
            var userName = await _context.UserNames.FindAsync(id);

            if (userName == null)
            {
                return NotFound();
            }

            return userName;
        }

        // PUT: api/UserNames/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Useradminapikey]
        public async Task<IActionResult> PutUserName(int id, UserName userName)
        {
            if (id != userName.Id)
            {
                return BadRequest();
            }

            _context.Entry(userName).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserNameExists(id))
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

        // POST: api/UserNames
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Useradminapikey]
        public async Task<ActionResult<UserName>> PostUserName(UserName userName)
        {
            _context.UserNames.Add(userName);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserName", new { id = userName.Id }, userName);
        }

        // DELETE: api/UserNames/5
        [HttpDelete("{id}")]
        [Useradminapikey]
        public async Task<IActionResult> DeleteUserName(int id)
        {
            var userName = await _context.UserNames.FindAsync(id);
            if (userName == null)
            {
                return NotFound();
            }

            _context.UserNames.Remove(userName);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserNameExists(int id)
        {
            return _context.UserNames.Any(e => e.Id == id);
        }
    }
}
