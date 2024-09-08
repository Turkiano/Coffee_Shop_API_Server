using Coffee_Shop_App.src.Abstractions;
using Coffee_Shop_App.src.Databases;
using Microsoft.EntityFrameworkCore;

namespace Coffee_Shop_App.src.Repositories;

public class ReviewRepository : IReviewRepository
{

    private DbSet<Review> _reviews;

    public ReviewRepository(DatabaseContext databaseContext)
    {
        _reviews = databaseContext.Reviews;
    }

    public Review CreateOne(Review review)
    {
        _reviews.Add(review);
        return review;
    }

    public IEnumerable<Review> FindAll()
    {
        return _reviews;
    }

    public Review FindOne(Guid reviewId)
    {
        Review? review = _reviews.FirstOrDefault(review => review.Id == reviewId);

        return review;
    }

}