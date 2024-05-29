using Microsoft.AspNetCore.Mvc;
using Worktastic.Models;

namespace Worktastic.Controllers
{
    public class JobPostingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateEditJobPosting(int id)
        {
            return View();
        }

        public IActionResult CreateEditJob(JobPosting jobPosting,IFormFile file)
        {
            if(file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var bytes = ms.ToArray();
                    jobPosting.CompanyImage = bytes;
                }
            }
            return RedirectToAction("Index");
        }
    } 
}
