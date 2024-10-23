using DotnetAndGraphQL.Domain;
using DotnetAndGraphQL.Domain.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetAndGraphQL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCustomers")]
        public async Task<IEnumerable<Customer>> GetAllAsync(AppDbContext dbContext)
        {
            return await dbContext.Customers.Include(c => c.Contacts).ToListAsync();
                
        }      

        [HttpPost(Name = "AddCustomer")]
        public async Task<IActionResult> PostAsync(Customer customer, AppDbContext dbContext)
        {
            dbContext.Customers.Add(customer);
            await dbContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpGet("contacts", Name = "GetContacts")]
        public async Task<IEnumerable<Contact>> GetAllContactsAsync(AppDbContext dbContext)
        {
            return await dbContext.Contacts.ToListAsync();
        }

    }
}
