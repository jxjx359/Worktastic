using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worktastic.Models
{
    public class JobPosting
    {
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? JobLocation { get; set; }
        public string? Description { get; set; }
        public Int32? Salary { get; set; }  // Nullable decimal
        public DateTime? StartDate { get; set; }  // Nullable DateTime
        public string? CompanyName { get; set; }
        public string? ContactWebsite { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactMail { get; set; }  // Nullable string
        public byte[]? CompanyImage { get; set; }  // Nullable byte array
        public string? OwnerUsername { get; set; }
    }
}
