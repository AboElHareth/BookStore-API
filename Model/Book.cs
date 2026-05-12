using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public string BookUrl { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey("publisher")]
        public int? PublisherId { get; set; }
        public Publisher publisher { get; set; }
        public List<BookAuthor> bookauthors { get; set; }
    }
}
