namespace BookShoppingCartMvcUI.Models
{
    public class IndexVm
    {
        public IndexVm()
        {
            Categories = new List<Genre>();
            Books = new List<Book>();
            Reviews = new List<Review>();

        }
        public List<Genre> Categories { get; set; }
        public List<Book> Books { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
