using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class Dish
    {
        public long Id { get; set; }
        [ForeignKey("DishType")]
        public int  TypeId{ get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }

        public virtual ICollection<KitchenOrder> KitchenOrders { get; set; }
        public virtual ICollection<DishRecipe> DishRecipes { get; set; }
        public virtual DishType DishType { get; set; }
    }
}