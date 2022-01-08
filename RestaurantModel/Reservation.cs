namespace RestaurantModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservation
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }

        public TimeSpan time { get; set; }

        [Required]
        [StringLength(50)]
        public string client { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string phone_number { get; set; }

        [StringLength(50)]
        public string observations { get; set; }

        public int? people_expected { get; set; }

        public int? table_id { get; set; }

        public virtual Table Table { get; set; }
    }
}
