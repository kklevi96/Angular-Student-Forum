using EFCUTY_ASP_2022231.Models;
using EFCUTY_ASP_2022231.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EFCUTY_ASP_2022231.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsApiController : ControllerBase
    {
        private readonly ISubjectsRepository repository;
        private readonly UserManager<ApiUser> userManager;

        public SubjectsApiController(ISubjectsRepository repository, UserManager<ApiUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }



        // GET: Subjects
        [HttpGet]
        public IActionResult Index()
        {
            string SiteUserId = userManager.GetUserId(User);
            return Ok(this.repository.GetAll().OrderBy(s => s.Semester));
        }

        // GET: Subjects/Details/5
        [HttpGet("Details/{id}")]
        public IActionResult Details(string id)
        {
            var subject = this.repository.GetOne(id);

            if (id == null || subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Create")]
        public IActionResult Create(Subject subject)
        {
            if (String.IsNullOrEmpty(subject.Name) || String.IsNullOrEmpty(subject.SubjectCode) || repository.GetAll().Any(s => s.SubjectCode == subject.SubjectCode))
                return BadRequest();

            if (!User.IsInRole("Admin"))
                return Unauthorized();

            Subject n = new Subject()
            {
                Semester = subject.Semester,
                CreditValue = subject.CreditValue,
                ExamSubject = subject.ExamSubject,
                Name = subject.Name,
                SubjectCode = subject.SubjectCode
            };
            this.repository.Create(n);
            return Ok(n);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut("Edit/{id}")]
        public IActionResult Edit(string id, Subject subject)
        {
            if (!String.IsNullOrEmpty(subject.Name))
            {
                var old = this.repository.GetOne(id);

                if (!User.IsInRole("Admin"))
                {
                    return Unauthorized();
                }

                old.Name = subject.Name;
                old.Semester = subject.Semester;
                old.ExamSubject = subject.ExamSubject;
                old.CreditValue = subject.CreditValue;
                this.repository.Update(old);

                return Ok(old);
            }
            return BadRequest(subject);
        }

        // GET: Subjects/Delete/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var subject = this.repository.GetOne(id);

            if (subject != null && User.IsInRole("Admin"))
            {
                this.repository.Delete(subject);
                return Ok(subject);
            }

            return Unauthorized();
        }
    }
}
