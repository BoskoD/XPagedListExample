using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebGridDemo.Models;
using WebGridDemo.Repository;
using X.PagedList;

namespace WebGridDemo.Controllers
{
    public class DemoController : Controller
    {
        IProduct _IProduct;
        public DemoController(IProduct IProduct)
        {
            _IProduct = IProduct;
        }
        public IActionResult Grid(int? page = 1)
        {
            ProductPagingInfo ProductPagingInfo = new ProductPagingInfo();

            if (page < 0)
            {
                page = 1;
            }

            var pageIndex = (page ?? 1) - 1;
            var pageSize = 5;

            int totalProductCount = _IProduct.GetProductsCount();
            var products = _IProduct.ProductPagination( page, pageSize).ToList();
            var productsPagedList = new StaticPagedList<Product>(products, pageIndex + 1, pageSize, totalProductCount);
            ProductPagingInfo.Products = productsPagedList;
            ProductPagingInfo.pageSize = page;
            return View(ProductPagingInfo);

        }
    }
}