using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;

        }

        public IEnumerable<Department> GetAllDepartments()
        {
            var depos = _connection.Query<Department>("SELECT * FROM DEPARTMENTS");

            return depos;
        }

        public void InsertDepartment(string newDepartmentName)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name) VALUES (@departmentName);", 
            new { departmentName = newDepartmentName });
        }
    }   
}
