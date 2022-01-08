using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Restaurant.RestaurantModel
{
    public partial class Reservation
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name ="Date & Time")]
        public DateTime date { get; set; }
       
        [Required]
        [StringLength(50)]
       [Display(Name ="Client Name")]
        public string client { get; set; }

        [Required]
        [StringLength(50)]
       [Display(Name ="Client Email")]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        [Display (Name = "Phone Number")]
        public string phone_number { get; set; }

        [StringLength(50)]
        [Display (Name = "Observations")]
        public string observations { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value equal with or greater than {1}")]
        [Display(Name ="Number of people")]
        public int? people_expected { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value equal with or greater than {1}")]
        [Display(Name = "Table number")]
        public int? table_id { get; set; }

        public virtual Table Table { get; set; }
    }
}
