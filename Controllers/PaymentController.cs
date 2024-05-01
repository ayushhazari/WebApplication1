using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class PaymentController : ControllerBase
        {
            private readonly InfoContext _infoContext;

            public PaymentController(InfoContext infoContext)
            {
                _infoContext = infoContext;
            }

            [HttpGet]
            public async Task<IEnumerable<Payment>> Get()
            {
                return await _infoContext.Payments.ToListAsync();
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                if (id < 1)
                    return BadRequest();

                var payment = await _infoContext.Payments.FirstOrDefaultAsync(p => p.PaymentId == id);
                if (payment == null)
                    return NotFound();

                return Ok(payment);
            }

        [HttpPost]
        public async Task<IActionResult> Post(Payment payment)
        {
            if (payment == null)
                return BadRequest();

            payment.PaymentId = 0; 

            _infoContext.Add(payment);
            await _infoContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = payment.PaymentId }, payment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();

            var payment = await _infoContext.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();

            _infoContext.Payments.Remove(payment);
            await _infoContext.SaveChangesAsync();

            return Ok();
        }
    }
    }