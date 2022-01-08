namespace RestaurantModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Items
    {
        public int Id { get; set; }

        public int quantity { get; set; }

        public int? order_id { get; set; }

        public int? menu_id { get; set; }

        public virtual Menu_items Menu_items { get; set; }

        public virtual Order Order { get; set; }
    }
}
