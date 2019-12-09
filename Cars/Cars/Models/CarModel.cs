using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        [Display(Name = "Brand name.")]
        public string Name { get; set; }

        [Display(Name = "Brand model.")]
        public string Brand { get; set; }
    }
}
