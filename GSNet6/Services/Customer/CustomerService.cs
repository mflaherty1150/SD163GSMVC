using GSNet6.Data;
using GSNet6.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace GSNet6.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly Sd163gsapiContext _ctx;

        public CustomerService(Sd163gsapiContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<CustomerIndexModel>> GetAllCustomersAsync()
        {
            var customers = _ctx.Customers.Select(customer => new CustomerIndexModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
            });
            return customers;
        }

        public async Task<bool> CreateCustomerAsync(CustomerCreateModel model)
        {
            _ctx.Customers.Add(new Data.Customer()
            {
                Name = model.Name,
                Email = model.Email,
            });
            if (await _ctx.SaveChangesAsync() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
