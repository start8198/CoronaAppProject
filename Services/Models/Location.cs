using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Location
    {
        [Required(ErrorMessage = "This field is required"), MinLength(2, ErrorMessage = "2 characters at Least"), MaxLength(20, ErrorMessage = "20 characters at most")]
        public string City { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "This field is required"), MinLength(2, ErrorMessage = "2 characters at Least"), MaxLength(20, ErrorMessage = "20 characters at most")]
        public string Location1 { get; set; }



    }
}
