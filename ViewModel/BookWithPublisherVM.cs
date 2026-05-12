namespace BookStore.ViewModel
{
    public class BookWithPublisherVM
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorsName { get; set; }
    }
}
