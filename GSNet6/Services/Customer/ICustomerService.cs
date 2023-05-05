using GSNet6.Models.Customer;

namespace GSNet6.Services.Customer
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerIndexModel>> GetAllCustomersAsync();
        Task<bool> CreateCustomerAsync(CustomerCreateModel model);
    }
}
