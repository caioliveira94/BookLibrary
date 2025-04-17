namespace BookLibrary.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string Type { get; set; } = null!;
        public string ISBN { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
