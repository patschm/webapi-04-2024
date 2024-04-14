namespace ProductsReviews.DAL.Entities;

public class Review
{
   public int Id { get; set; }
    public string? Author { get; set; }
    public string? Email { get; set; }
    public string? Text { get; set; }
    public int Score { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}