using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipTypesController : ControllerBase
    {
        private readonly ToDoContext _context;

        public MembershipTypesController(ToDoContext context)
        {
            _context = context;
        }

        // GET: api/MembershipTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipType>>> GetMembershipTypeItems()
        {
            return await _context.MembershipTypeItems.ToListAsync();
        }

        // GET: api/MembershipTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipType>> GetMembershipType(int id)
        {
            var membershipType = await _context.MembershipTypeItems.FindAsync(id);

            if (membershipType == null)
            {
                return NotFound();
            }

            return membershipType;
        }

        // PUT: api/MembershipTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembershipType(int id, MembershipType membershipType)
        {
            if (id != membershipType.Id)
            {
                return BadRequest();
            }

            _context.Entry(membershipType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipTypeExists(id))
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

        // POST: api/MembershipTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MembershipType>> PostMembershipType(MembershipType membershipType)
        {
            _context.MembershipTypeItems.Add(membershipType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembershipType", new { id = membershipType.Id }, membershipType);
        }

        // DELETE: api/MembershipTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembershipType(int id)
        {
            var membershipType = await _context.MembershipTypeItems.FindAsync(id);
            if (membershipType == null)
            {
                return NotFound();
            }

            _context.MembershipTypeItems.Remove(membershipType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembershipTypeExists(int id)
        {
            return _context.MembershipTypeItems.Any(e => e.Id == id);
        }
    }
}
