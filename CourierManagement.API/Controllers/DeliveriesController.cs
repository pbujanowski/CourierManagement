using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourierManagement.Core.Models;
using CourierManagement.DataAccess.Data;

namespace CourierManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DeliveriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/Deliveries
        [HttpGet]
        public IEnumerable<Delivery> GetDeliveries()
        {
            return context.Deliveries;
        }

        // GET: api/Deliveries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDelivery([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var delivery = await context.Deliveries.FindAsync(id).ConfigureAwait(false);

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        // PUT: api/Deliveries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery([FromRoute] int id, [FromBody] Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != delivery.Id)
            {
                return BadRequest();
            }

            context.Entry(delivery).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
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

        // POST: api/Deliveries
        [HttpPost]
        public async Task<IActionResult> PostDelivery([FromBody] Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Deliveries.Add(delivery);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return CreatedAtAction("GetDelivery", new { id = delivery.Id }, delivery);
        }

        // DELETE: api/Deliveries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var delivery = await context.Deliveries.FindAsync(id).ConfigureAwait(false);
            if (delivery == null)
            {
                return NotFound();
            }

            context.Deliveries.Remove(delivery);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return Ok(delivery);
        }

        private bool DeliveryExists(int id)
        {
            return context.Deliveries.Any(e => e.Id == id);
        }
    }
}