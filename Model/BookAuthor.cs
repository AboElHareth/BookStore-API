using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Model
{
    public class BookAuthor
    {
        public int Id { get; set; }
        [ForeignKey("book")]
        public int BookId { get; set; }
        public Book book { get; set; }
        [ForeignKey("author")]
        public int AuthorId { get; set; }
        public Author author { get; set; }
    }
}
