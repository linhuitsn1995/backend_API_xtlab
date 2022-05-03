#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhmucsController : ControllerBase
    {
        private readonly XtlabContext _context;

        public DanhmucsController(XtlabContext context)
        {
            _context = context;
        }

        // GET: api/Danhmucs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Danhmuc>>> GetDanhmucs()
        {
            return await _context.Danhmucs.ToListAsync();
        }

        // GET: api/Danhmucs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Danhmuc>> GetDanhmuc(int id)
        {
            var danhmuc = await _context.Danhmucs.FindAsync(id);

            if (danhmuc == null)
            {
                return NotFound();
            }

            return danhmuc;
        }

        // PUT: api/Danhmucs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDanhmuc(int id, Danhmuc danhmuc)
        {
            if (id != danhmuc.DanhmucId)
            {
                return BadRequest();
            }

            _context.Entry(danhmuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhmucExists(id))
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

        // POST: api/Danhmucs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Danhmuc>> PostDanhmuc(Danhmuc danhmuc)
        {
            _context.Danhmucs.Add(danhmuc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDanhmuc", new { id = danhmuc.DanhmucId }, danhmuc);
        }

        // DELETE: api/Danhmucs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDanhmuc(int id)
        {
            var danhmuc = await _context.Danhmucs.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            _context.Danhmucs.Remove(danhmuc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DanhmucExists(int id)
        {
            return _context.Danhmucs.Any(e => e.DanhmucId == id);
        }
    }
}
