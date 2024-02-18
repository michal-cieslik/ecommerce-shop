using ecommerce_shop.Interfaces;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Review> CreateReviewAsync(Review newReview)
        {
            _context.Reviews.Add(newReview);
            await _context.SaveChangesAsync();
            return newReview;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<List<Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await _context.Reviews.Where(r => r.ProductId == productId).ToListAsync();
        }

        public async Task<Review> UpdateReviewAsync(int id, Review updatedReview)
        {
            Review review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review != null)
            {
                review.Rating = updatedReview.Rating;
                review.Comment = updatedReview.Comment;
                review.DateUpdated = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            return review;
        }

        public async Task<Review> DeleteReviewAsync(int id)
        {
            Review review = await _context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return review;
            }
            return null;
        }
    }
}
