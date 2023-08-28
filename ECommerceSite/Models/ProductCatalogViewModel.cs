namespace ECommerceSite.Models
{
    public class ProductCatalogViewModel
    {
        public List<Product> Products { get; private set; }
        public int CurrentPage { get; private set; }
        public int LastPage { get; private set; }

        public ProductCatalogViewModel(List<Product> products, int lastPage, int currentPage)
        {
            Products = products;
            CurrentPage = currentPage;
            LastPage = lastPage;
        }
    }
}
