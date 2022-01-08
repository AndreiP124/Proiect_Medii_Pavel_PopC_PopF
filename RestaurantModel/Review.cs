using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Restaurant.RestaurantModel
{
    public partial class Review
    {
        public int Id { get; set; }

        public int? rating { get; set; }

        [Required]
        [StringLength(50)]
        public string comments { get; set; }

        [Required]
        [StringLength(50)]
        public string sender_email { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }
}
