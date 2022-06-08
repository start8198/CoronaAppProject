using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Patient
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Id { get; set; }

        public List<Location> Locations { get; set; }

    }
}
