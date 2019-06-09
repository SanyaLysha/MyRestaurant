using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Entities
{
    public class DishType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}