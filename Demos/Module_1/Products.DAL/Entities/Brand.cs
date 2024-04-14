namespace Products.DAL.Entities;

public class Brand
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Product> Products { get; set; } = new HashSet<Product>(); 
}