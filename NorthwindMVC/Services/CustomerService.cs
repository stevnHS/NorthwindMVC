using NorthwindMVC.Models;
using NorthwindMVC.Repositories;
using NorthwindMVC.Services.Dtos;

namespace NorthwindMVC.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.CustomerId,
                Name = c.CompanyName,

            });
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return new CustomerDto
            {
                Id = customer.CustomerId,
                Name = customer.CompanyName,

            };
        }

        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                CompanyName = customerDto.Name,

            };
            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                CustomerId = customerDto.Id,
                CompanyName = customerDto.Name,

            };
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

    }
}
