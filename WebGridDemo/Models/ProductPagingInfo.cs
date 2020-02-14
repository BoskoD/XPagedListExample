using X.PagedList;

namespace WebGridDemo.Models
{
    public class ProductPagingInfo
    {
        public int? pageSize;
        public StaticPagedList<Product> Products { get; set; }
    }
}
