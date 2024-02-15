﻿using ecommerce_shop.Models;

namespace ecommerce_shop.Services
{
    public interface IReviewService
    {
        Task<Review> CreateReviewAsync(Review newReview);
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> GetReviewByIdAsync(int id);
        Task<Review> UpdateReviewAsync(int id, Review updatedReview);
        Task<Review> DeleteReviewAsync(int id);
    }
}
