using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.RestaurantModel
{
    public partial class Menu_items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu_items()
        {
            Order_Items = new HashSet<Order_Items>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Category")]
        public string category { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Dish")]
        public string name { get; set; }

        [Display(Name ="Price")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a price bigger than {1}")]
        public int price { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Description")]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Items> Order_Items { get; set; }
    }
}
