using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IReviewService reviewService) : ControllerBase
    {
        private readonly IReviewService _reviewService = reviewService;

        [HttpPost]
        public async Task<IActionResult> CreateReviewAsync([FromBody] Review newReview)
        {
            Review review = await _reviewService.CreateReviewAsync(newReview);
            return Ok(review);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviewsAsync()
        {
            List<Review> reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewByIdAsync(int id)
        {
            Review review = await _reviewService.GetReviewByIdAsync(id);
            return Ok(review);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReviewAsync(int id, [FromBody] Review updatedReview)
        {
            Review review = await _reviewService.UpdateReviewAsync(id, updatedReview);
            return Ok(review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewAsync(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return Ok();
        }
    }
}