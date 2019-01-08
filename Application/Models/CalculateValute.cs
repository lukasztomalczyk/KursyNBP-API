using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Models
{
    public class CalculateValute
    {
        [Required]
        public decimal basiccurrencyinput { get; set; }
        [Required]
        public string basiccurrencycode { get; set; }
        [Required]
        public string targetcurrencycode { get; set; }

        public decimal basiccurrency { get; set; }
        public decimal targetcurrency { get; set; }
        public decimal value { get; set; }
    }
}
