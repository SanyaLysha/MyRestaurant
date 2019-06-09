using Restaurant.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class UserSalary
    {
        [Key,ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Salary")]
        public int SalaryId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Salary Salary { get; set; }
    }
}