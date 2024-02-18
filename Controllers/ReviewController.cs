using ecommerce_shop.Models;
using Microsoft.AspNetCore.Mvc;
using ecommerce_shop.Services;
using Microsoft.AspNetCore.Authorization;
using ecommerce_shop.Data;
using System.Security.Claims;

namespace ecommerce_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public ReviewController(DataContext context) : base()
        {
            var _reviewRepository = new ReviewRepository(context);
            _reviewService = new ReviewService(_reviewRepository);
        }
        private readonly IReviewService _reviewService;


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReviewAsync([FromBody] Review newReview)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            newReview.UserId = userId;
            newReview.DateAdded = DateTime.UtcNow;
            Review review = await _reviewService.CreateReviewAsync(newReview);
            return Ok(review);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviewsAsync()
        {
            List<Review> reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("Product/{ProductId:int}")]
        public async Task<IActionResult> GetReviewsByProductIdAsync(int ProductId)
        {
            List<Review> reviews = await _reviewService.GetReviewsByProductIdAsync(ProductId);
            return Ok(reviews);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReviewAsync(int id, [FromBody] Review updatedReview)
        {
            Review review = await _reviewService.UpdateReviewAsync(id, updatedReview);
            return Ok(review);
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReviewAsync(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return Ok();
        }
    }
}