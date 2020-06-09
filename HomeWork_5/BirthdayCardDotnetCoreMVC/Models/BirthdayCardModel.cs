using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayCardDotnetCoreMVC.Models
{
    public class BirthdayCardModel
    {
        [Required(ErrorMessage ="Please Enter From")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please Enter To")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please Enter Message")]
        public string Message { get; set; }
    }
}
