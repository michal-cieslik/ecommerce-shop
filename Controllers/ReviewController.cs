using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(ReviewService reviewService) : ControllerBase
    {
        private readonly ReviewService _reviewService = reviewService;

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review newReview)
        {
            Review review = await _reviewService.CreateReviewAsync(newReview);
            return Ok(review);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            List<Review> reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            Review review = await _reviewService.GetReviewByIdAsync(id);
            return Ok(review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] Review updatedReview)
        {
            Review review = await _reviewService.UpdateReviewAsync(id, updatedReview);
            return Ok(review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return Ok();
        }
    }
}