using NorthwindMVC.Services.DTOs;

namespace NorthwindMVC.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerDto customerDto);
        Task UpdateCustomerAsync(CustomerDto customerDto);
        Task DeleteCustomerAsync(int id);
    }
}
