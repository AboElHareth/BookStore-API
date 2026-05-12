namespace BookStore.ViewModel
{
    public class BookVM
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public string BookUrl { get; set; }
        public int PublisherId { get; set; }
        public List<int> AuthorsId { get; set; }
    }
}
