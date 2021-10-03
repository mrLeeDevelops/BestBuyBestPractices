using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAllProducts();
        void CreateProduct(string name, double price, int categoryID);
        void UpdateProducts(string name, double price, int OnSale, int stockLevel);
    }
}
