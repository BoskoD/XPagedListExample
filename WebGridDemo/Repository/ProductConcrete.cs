using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebGridDemo.Models;

namespace WebGridDemo.Repository
{
    public class ProductConcrete : IProduct
    {
        public int GetProductsCount()
        {
            using (SqlConnection con = new SqlConnection(ShareConnectionString.Value))
            {
                var para = new DynamicParameters();
                var data = con.Query<int>("GetProductCount", para, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return data;
            }
        }

        public List<Product> ProductPagination(int? pageNumber, int pageSize)
        {
            using (SqlConnection con = new SqlConnection(ShareConnectionString.Value))
            {
                var para = new DynamicParameters();
                para.Add("@PageNumber", pageNumber);
                para.Add("@PageSize", pageSize);
                var data = con.Query<Product>("ProductPagination", para, commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
        }

    }
}
