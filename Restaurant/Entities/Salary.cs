using Restaurant.Models;
using System.Collections.Generic;

namespace Restaurant.Entities
{
    public class Salary
    {
        public int Id { get; set; }
        public int Size { get; set; }

        public virtual ICollection<UserSalary> UsersSalary { get; set; }
    }
}