using Microsoft.AspNetCore.Mvc;
using Worktastic.Data;
using Worktastic.Models;

namespace Worktastic.Controllers
{
    public class JobPostingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobPostingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var JobPostingsFromDb = _context.JobPostings.Where(x => x.OwnerUsername == User.Identity.Name).ToList();
            return View(JobPostingsFromDb);
        }
        public IActionResult CreateEditJobPosting(int id)
        {
            if(id != 0)
            {
                var jobPostingFromdb = _context.JobPostings.SingleOrDefault(x => x.Id == id);

                if(jobPostingFromdb != null)
                {
                    return View(jobPostingFromdb);
                }
                else
                {
                    return NotFound();
                }
            }

            return View();
        }

        public IActionResult CreateEditJob(JobPosting jobPosting,IFormFile file)
        {
            jobPosting.OwnerUsername = User.Identity.Name;

            if(file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var bytes = ms.ToArray();
                    jobPosting.CompanyImage = bytes;
                }
            }

            if(jobPosting.Id == 0)
            {
                // Add new job if not editing
                _context.JobPostings.Add(jobPosting);
            }
            else
            {
                var jobFromDb = _context.JobPostings.SingleOrDefault(x => x.Id == jobPosting.Id);
                
                if(jobFromDb == null)
                {
                    return NotFound();
                }

                jobFromDb.CompanyImage = jobPosting.CompanyImage;
                jobFromDb.CompanyName = jobPosting.CompanyName;
                jobFromDb.ContactMail = jobPosting.ContactMail;
                jobFromDb.ContactPhone = jobPosting.ContactPhone;
                jobFromDb.ContactWebsite = jobPosting.ContactWebsite;
                jobFromDb.Description = jobPosting.Description;
                jobFromDb.JobLocation = jobPosting.JobLocation;
                jobFromDb.JobTitle = jobPosting.JobTitle;
                jobFromDb.Salary = jobPosting.Salary;
                jobFromDb.StartDate = jobPosting.StartDate;
                jobFromDb.OwnerUsername = jobPosting.OwnerUsername;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    } 
}
