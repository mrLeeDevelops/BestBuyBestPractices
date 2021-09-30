using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;


namespace BestBuyBestPractices
{
    public class DapperProductsRepository : IProductsRepository

    {
        private readonly IDbConnection _connection2;
        //Constructor
        public DapperProductsRepository(IDbConnection connection2)
        {
            _connection2 = connection2;

        }

        public IEnumerable<Products> GetAllProducts()
        {
            var depos = _connection2.Query<Products>("SELECT * FROM PRODUCTS");

            return depos;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection2.Execute("INSERT INTO PRODUCTS(Name, Price, CategoryID) VALUES (@name,@price, @categoryID);",
            new { productsName = (name, price, categoryID) });

        }
    }
}
