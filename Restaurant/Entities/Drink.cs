using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class Drink
    {
        public long Id { get; set; }
        [ForeignKey("DrinkType")]
        public int TypeId { get; set; }
        public string Name { get; set; }
        public float Volume { get; set; }
        public float Price { get; set; }

        public virtual ICollection<BarOrder> BarOrders { get; set; }
        public virtual ICollection<DrinkRecipe> DrinkRecipes { get; set; }
        public virtual DrinkType DrinkType { get; set; }
    }
}