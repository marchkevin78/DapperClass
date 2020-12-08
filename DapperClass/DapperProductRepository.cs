using System;
using System.Data;
using System.Collections.Generic;
using Dapper;


namespace DapperClass 
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void CreateProduct(int newProductID, string newProductName, double newPrice, int newCategoryID, int newOnSale, int newStockLevel)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name) VALUES (@productName);",
            new { productName = newProductName });
        }

        public void UpdateProduct(int updatedProductID, string updatedProductName, double updatedPrice, int updatedCategoryID, int updatedOnSale, int updatedStockLevel)
        {
            _connection.Execute("UPDATE products SET Name = @name WHERE ProductID = @id;" , new { name = updatedProductName, id = updatedProductID });
        }

        public void DeleteProduct(int id)
        {
            _connection.Execute("DELETE FROM products WHERE productID = @id;", new { id = id });
        }


    }
}
