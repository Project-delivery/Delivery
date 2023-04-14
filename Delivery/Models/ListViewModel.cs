namespace Delivery.Models
{
    public class ListViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public static ListViewModel<T> GetModel(IEnumerable<T> items, int pageNo, int pageSize)
        {
            var count = items.Count();
            var itemsOnPage = items.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            return new ListViewModel<T>
            {
                Items = itemsOnPage,
                PagingInfo = new PagingInfo { CurrentPage = pageNo, ItemsPerPage = pageSize, TotalItems = count }
            };
        }
    }
}
