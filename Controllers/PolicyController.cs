using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class PolicyController : Controller
    {

            private readonly InfoContext _infoContext;

            public PolicyController(InfoContext infoContext)
            {
                _infoContext = infoContext;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var policies = await _infoContext.Policies.ToListAsync();
                return Ok(policies);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                if (id < 1)
                    return BadRequest();

                var policy = await _infoContext.Policies.FirstOrDefaultAsync(p => p.EmpId == id);
                if (policy == null)
                    return NotFound();

                return Ok(policy);
            }
/*
            [HttpPost]
            public async Task<IActionResult> Post(PolicyDetail policy)
            {
                if (policy == null)
                    return BadRequest();

                //policy.PolicyId = 0; 

                _infoContext.Add(policy);
                await _infoContext.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new {  }, policy);
            }

            [HttpPut]
            public async Task<IActionResult> Put(Policy policyData)
            {
                if (policyData == null || policyData.PolicyId == 0)
                    return BadRequest();

                var policy = await _infoContext.Policies.FindAsync(policyData.PolicyId);
                if (policy == null)
                    return NotFound();

                policy.PolicyName = policyData.PolicyName;
                policy.StartDate = policyData.StartDate;
                policy.EndDate = policyData.EndDate;
                policy.EmpId = policyData.EmpId;
                policy.InsurenceCompany = policyData.InsurenceCompany;

                await _infoContext.SaveChangesAsync();
                return Ok();
            }
*/
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                if (id < 1)
                    return BadRequest();

                var policy = await _infoContext.Policies.FindAsync(id);
                if (policy == null)
                    return NotFound();

                _infoContext.Policies.Remove(policy);
                await _infoContext.SaveChangesAsync();

                return Ok();
            }
        }
    }