using ecommerce_shop.Data;
using ecommerce_shop.Interfaces;
using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Services
{
    public class ReviewService : IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        private readonly IReviewRepository _reviewRepository;

        public async Task<Review> CreateReviewAsync(Review newReview)
        {
            return await _reviewRepository.CreateReviewAsync(newReview);
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepository.GetAllReviewsAsync();
        }

        public async Task<List<Review>> GetReviewsByProductIdAsync(int ProductId)
        {
            return await _reviewRepository.GetReviewsByProductIdAsync(ProductId);
        }

        public async Task<Review> UpdateReviewAsync(int id, Review updatedReview)
        {
            return await _reviewRepository.UpdateReviewAsync(id, updatedReview);
        }

        public async Task<Review> DeleteReviewAsync(int id)
        {
            return await _reviewRepository.DeleteReviewAsync(id);
        }
    }
}
