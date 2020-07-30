using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment4.Data;
using Assignment4.Models;

namespace Assignment4.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly TrainDbContext _context;

        public TrainsController(TrainDbContext context)
        {
            _context = context;
        }

        // GET: api/Trains
        [HttpGet]
        public IEnumerable<Train> GetTrain()
        {
            return _context.Train;
        }

        // GET: api/Trains/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrain([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var train = await _context.Train.FindAsync(id);

            if (train == null)
            {
                return NotFound();
            }

            return Ok(train);
        }

        // PUT: api/Trains/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrain([FromRoute] int id, [FromBody] Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != train.Id)
            {
                return BadRequest();
            }

            _context.Entry(train).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainExists(id))
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

        // POST: api/Trains
        [HttpPost]
        public async Task<IActionResult> PostTrain([FromBody] Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Train.Add(train);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrain", new { id = train.Id }, train);
        }

        // DELETE: api/Trains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrain([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var train = await _context.Train.FindAsync(id);
            if (train == null)
            {
                return NotFound();
            }

            _context.Train.Remove(train);
            await _context.SaveChangesAsync();

            return Ok(train);
        }

        private bool TrainExists(int id)
        {
            return _context.Train.Any(e => e.Id == id);
        }
    }
}