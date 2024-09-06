

using Coffee_Shop_App.src.DTOs;

namespace Coffee_Shop_App.src.Abstractions;
public interface IReviewService
{

    public ReviewReadDto FindOne(string reviewId);
    public IEnumerable<Review> FindAll();
    public Review CreateOne(Review review);





}