using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public bool Paid { get; set; }
        [ForeignKey("Table")]
        public int TableId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Table Table { get; set; }
        public virtual ICollection<BarOrder> BarOrders { get; set; }
        public virtual ICollection<KitchenOrder> KitchenOrders { get; set; }

    }
}