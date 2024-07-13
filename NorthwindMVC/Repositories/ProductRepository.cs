using System.Data;
using Dapper;
using NorthwindMVC.Models;

namespace NorthwindMVC.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection connection)
        {
            _conn = connection;
        }
        public async Task AddAsync(Product product)
        {
            string sql = "INSERT INTO Products (ProductName, UnitPrice) VALUES (@ProductName, @UnitPrice);";
            await _conn.ExecuteAsync(sql, product);
        }

        public async Task DeleteAsync(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId=@Id;";
            await _conn.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {

            var sql = "SELECT * FROM Products";
            return await _conn.QueryAsync<Product>(sql);

        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products where ProductID = @Id";
            return await _conn.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });

        }

        public async Task UpdateAsync(Product product)
        {
            // 只能修改名稱跟價格，不像 ef 可以直接對應，要修改其他欄位就要改改 sql
            string sql = @"UPDATE Products
                            SET ProductName = @Name, UnitPrice = @Price
                            WHERE ProductId = @Id ";

            await _conn.ExecuteAsync(sql, new
            {
                Name = product.ProductName,
                Price = product.UnitPrice,
                Id = product.ProductId
            });
        }
    }


}
