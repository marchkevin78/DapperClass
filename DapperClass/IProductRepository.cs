using System;
using System.Collections.Generic;

namespace DapperClass
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(int newProductID, string newProductName, double newPrice, int newCategoryID, int newOnSale, int newStockLevel);
        public void UpdateProduct(int updatedProductID, string updatedProductName, double updatedPrice, int updatedCategoryID, int updatedOnSale, int updatedStockLevel);
        public void DeleteProduct(int id);
    }
}
