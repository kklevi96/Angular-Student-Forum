using EFCUTY_ASP_2022231.Models;
using EFCUTY_ASP_2022231.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EFCUTY_ASP_2022231.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentLikeApiController : ControllerBase
    {
        private readonly ICommentLikeRepository repository;
        private readonly UserManager<ApiUser> userManager;

        public CommentLikeApiController(ICommentLikeRepository repository, UserManager<ApiUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(this.repository.GetAll());

        }

        [HttpPost("ToggleLike/{id}")]
        public IActionResult ToggleLike(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (userManager.GetUserId(User) == null)
            {
                return Unauthorized();
            }
            else
            {
                string userId = userManager.GetUserId(User);

                if (repository.IsLikedBy(userId, id))
                {
                    repository.Remove(userId, id);
                    return Ok();
                }
                else if (!repository.IsLikedBy(userId, id))
                {
                    repository.Add(userId, id);
                    return Ok();
                }
            }
            return BadRequest();
        }


        [HttpPost("AddLike/{id}")]
        public IActionResult AddLike(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (userManager.GetUserId(User) == null)
            {
                return Unauthorized();
            }
            else
            {
                string userId = userManager.GetUserId(User);

                if (repository.IsLikedBy(userId, id))
                {
                    return BadRequest("Comment already liked");
                }
                else if (!repository.IsLikedBy(userId, id))
                {
                    repository.Add(userId, id);
                    return Ok();
                }
            }
            return BadRequest();
        }


        [HttpPost("RemoveLike/{id}")]
        public IActionResult RemoveLike(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (userManager.GetUserId(User) == null)
            {
                return Unauthorized();
            }
            else
            {
                string userId = userManager.GetUserId(User);

                if (repository.IsLikedBy(userId, id))
                {
                    repository.Remove(userId, id);
                    return Ok();
                }
                else if (!repository.IsLikedBy(userId, id))
                {
                    return BadRequest("Comment not liked yet!");
                }
            }
            return BadRequest();
        }

        [HttpGet("IsLiked/{id}")]
        public IActionResult IsLiked(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (userManager.GetUserId(User) == null)
            {
                return Unauthorized();
            }
            return Ok(repository.IsLikedBy(userManager.GetUserId(User), id));
        }
    }
}
