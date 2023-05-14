using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeMoney.DBases;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public OffersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            return await _context.Offer.ToListAsync();
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return offer;
        }

        // POST: api/Offers
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            _context.Offer.Add(offer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOffer), new { id = offer.Id }, offer);
        }

        // PUT: api/Offers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffer(int id, Offer offer)
        {
            if (id != offer.Id)
            {
                return BadRequest();
            }

            _context.Entry(offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(id))
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

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.Id == id);
        }   


        [HttpGet("{id}/MemOffers")]
        public async Task<ActionResult<IEnumerable<OfferMem>>> GetMemOffers(int id)
        {   
            var memOffers = await _context.Offer
                .Include(o => o.MemOffers)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (memOffers == null)
            {
                return NotFound();
            }

            return memOffers.MemOffers.ToList();
        }

        // GET: api/Offers/{id}/OffersMemAuthor
        [HttpGet("{id}/OffersMemAuthor")]
        public async Task<ActionResult<IEnumerable<OfferMemAuthor>>> GetOffersMemAuthor(int id)
        {
            var offersMemAuthor = await _context.Offer
                .Include(o => o.OffersMemAuthor)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (offersMemAuthor == null)
            {
                return NotFound();
            }

            return offersMemAuthor.OffersMemAuthor.ToList();
        }







    }
}
