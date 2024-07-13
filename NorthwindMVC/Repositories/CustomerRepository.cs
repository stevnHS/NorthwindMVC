using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using NorthwindMVC.Models;

namespace NorthwindMVC.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _conn;

        public CustomerRepository(IDbConnection connection)
        {
            _conn = connection;
        }

        public async Task<IEnumerable<Customer?>> GetAllAsync()
        {

            var sql = "SELECT * FROM Customers";
            return await _conn.QueryAsync<Customer>(sql);

        }

        public async Task<Customer?> GetByIdAsync(int id)
        {

            var sql = "SELECT * FROM Customers WHERE CustomerID = @Id";
            var customer = await _conn.QueryFirstOrDefaultAsync<Customer>(sql, new { Id = id });
            return customer;

        }

        public async Task AddAsync(Customer customer)
        {
            // await _context.Customers.AddAsync(customer);
            // await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            // _context.Customers.Update(customer);
            // await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // var customer = await GetByIdAsync(id);
            // if (customer != null)
            // {
            //     _context.Customers.Remove(customer);
            //     await _context.SaveChangesAsync();
            // }
        }
    }
}
