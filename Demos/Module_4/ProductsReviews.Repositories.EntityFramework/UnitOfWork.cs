using ProductsReviews.DAL.EntityFramework;
using ProductsReviews.DAL.Interfaces;

namespace ProductsReviews.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductReviewsContext _context;

    public UnitOfWork(ProductReviewsContext context)
    {
        _context = context;
        ProductGroupRepository = new ProductGroupRepository(_context);
        ProductRepository = new ProductRepository(_context);
        BrandRepository = new BrandRepository(_context);
        ReviewRepository = new ReviewRepository(_context);
    }

    public IProductGroupRepository ProductGroupRepository { get; }

    public IProductRepository ProductRepository {get;}

    public IBrandRepository BrandRepository {get;}

    public IReviewRepository ReviewRepository {get;}

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}