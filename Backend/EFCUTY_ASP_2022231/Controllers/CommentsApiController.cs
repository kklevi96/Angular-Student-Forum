using EFCUTY_ASP_2022231.Models;
using EFCUTY_ASP_2022231.Repository;
using EFCUTY_ASP_2022231.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EFCUTY_ASP_2022231.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsApiController : ControllerBase
    {
        private readonly ICommentsRepository repository;
        private readonly UserManager<ApiUser> userManager;

        public CommentsApiController(ICommentsRepository repository, UserManager<ApiUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        // GET: Comments
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(this.repository.GetAll());

        }

        [HttpGet("GetCommentsofPost/{id}")]
        public IActionResult GetCommentsofPost(string id)
        {
            return Ok(this.repository.GetAll().Where(p => p.PostId == id));
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        public IActionResult Create(CommentViewModel cvm)
        {
            if (userManager.GetUserId(User) == null)
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                Comment c = new Comment()
                {
                    Content = cvm.Content,
                    SiteUserId = userManager.GetUserId(User),
                    PostId = cvm.PostId,
                    Timestamp = DateTime.Now
                };
                this.repository.Create(c);
                return Ok(c);
            }
            return BadRequest();
        }

        // GET: Comments/Details/5
        [HttpGet("Details/{id}")]
        public IActionResult Details(string id)
        {
            Comment comment = this.repository.GetOne(id);

            if (id == null || comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("Edit/{id}")]
        public IActionResult Edit(string id, CommentViewModel comment)
        {
            var c = this.repository.GetOne(id);

            if (!String.IsNullOrEmpty(comment.Content))
            {
                if ((userManager.GetUserId(User) == c.SiteUserId) || User.IsInRole("Admin"))
                {

                    var old = this.repository.GetOne(id);
                    old.Content = comment.Content;
                    old.LastEdited = DateTime.Now;
                    old.EditCount++;
                    this.repository.Update(old);


                    return Ok(old);
                }
                return Unauthorized();

            }
            return BadRequest();
        }

        // GET: Comments/Delete/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var comment = this.repository.GetOne(id);

            if (comment == null)
            {
                return BadRequest();
            }
            if (userManager.GetUserId(User) != comment.SiteUserId && !User.IsInRole("Admin"))
            {
                return Unauthorized();
            }

            this.repository.Delete(comment);

            return Ok(comment);

        }
    }
}
