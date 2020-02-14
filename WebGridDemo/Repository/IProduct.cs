using System.Collections.Generic;
using WebGridDemo.Models;

namespace WebGridDemo.Repository
{
    public interface IProduct
    {
        int GetProductsCount();
        List<Product> ProductPagination(int? pageNumber, int pageSize);
    }
}
