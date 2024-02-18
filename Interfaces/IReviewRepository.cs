using ecommerce_shop.Models;

namespace ecommerce_shop.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> CreateReviewAsync(Review newReview);
        Task<List<Review>> GetAllReviewsAsync();
        Task<List<Review>> GetReviewsByProductIdAsync(int productId);
        Task<Review> UpdateReviewAsync(int id, Review updatedReview);
        Task<Review> DeleteReviewAsync(int id);
    }
}
