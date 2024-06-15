using EFCUTY_ASP_2022231.Models;
using EFCUTY_ASP_2022231.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EFCUTY_ASP_2022231.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICommentsRepository commentsRepository;
        private readonly IPostsRepository postsRepository;

        public AuthController(UserManager<ApiUser> userManager, RoleManager<IdentityRole> roleManager, ICommentsRepository commentsRepository, IPostsRepository postsRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.commentsRepository = commentsRepository;
            this.postsRepository = postsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id)
                };
                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nagyonhosszutitkoskodhelye"));
                var token = new JwtSecurityToken(
                 issuer: "http://www.security.org", audience: "http://www.security.org",
                 claims: claim, expires: DateTime.Now.AddMinutes(1440),
                 signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPut]
        public async Task<IActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            if (_userManager.Users.Select(t => t.UserName).Contains(model.UserName))
            {
                return BadRequest("A user with this username already exists!");
            }
            if (_userManager.Users.Select(t => t.Email).Contains(model.Email))
            {
                return BadRequest("A user with this email address already exists!");
            }
            var user = new ApiUser
            {
                Email = model.Email,
                UserName = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, "Student");
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserInfos()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.UserName == this.User.Identity.Name);
            if (user != null)
            {
                return Ok(new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user)
                });
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteMyself()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.UserName == this.User.Identity.Name);
            DeleteAllCommentsandPostsOfAuthor();
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("[action]")]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] RegisterViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.UserName == this.User.Identity.Name);
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            if (!(model.Password == null || model.Password.Length == 0))
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, model.Password);
            }
            await _userManager.UpdateAsync(user);
            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> DelegateAdmin()
        {

            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            if (user != null)
            {
                var role = new IdentityRole()
                {
                    Name = "Admin"
                };
                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(role);
                }
                await _userManager.AddToRoleAsync(user, "Admin");
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> RemoveAdmin()
        {
            var principal = this.User;
            var user = await _userManager.GetUserAsync(principal);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                return Ok();
            }
            return BadRequest();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult Admin()
        {
            if (User.IsInRole("Admin"))
                return Ok(_userManager.Users);
            return Unauthorized();
        }

        //[Authorize]
        //[HttpGet]
        //public async Task<IActionResult> GetUserInfos(string uid)
        //{
        //    var user = _userManager.Users.FirstOrDefault(t => t.UserName == this.User.Identity.Name);
        //    if (user != null)
        //    {
        //        return Ok(new
        //        {
        //            UserName = user.UserName,
        //            FirstName = user.FirstName,
        //            LastName = user.LastName,
        //            Email = user.Email,
        //            Roles = await _userManager.GetRolesAsync(user)
        //        });
        //    }
        //    return Unauthorized();
        //}

        [HttpDelete("DeleteCommentAndPostsOfAuthor")]
        public IActionResult DeleteAllCommentsandPostsOfAuthor()
        {
            var userId = this._userManager.GetUserId(User);

            var commentsToDelete = this.commentsRepository.GetAll().Where(c => c.SiteUserId == userId).ToList();
            var postsToDelete = this.postsRepository.GetAll().Where(c => c.SiteUserId == userId).ToList();


            foreach (var comment in commentsToDelete)
            {
                this.commentsRepository.Delete(comment); // Assuming you have a delete method in the repository.
            }

            foreach (var post in postsToDelete)
            {
                this.postsRepository.Delete(post); // Assuming you have a delete method in the repository.
            }

            return Ok();
        }
    }
}
