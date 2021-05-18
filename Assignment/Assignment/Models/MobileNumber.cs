using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class MobileNumber
    {
        [Required(ErrorMessage = "This field is required")]
        public decimal PhoneNumber { get; set; }
    }
}