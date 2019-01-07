using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Models
{
    public class CalculateValute
    {
        [Required]
        public double basiccurrencyinput { get; set; }
        [Required]
        public string basiccurrencycode { get; set; }
        [Required]
        public double targetcurrencyinput { get; set; }
        [Required]
        public string targetcurrencycode { get; set; }

        public double basiccurrency { get; set; }
        public double targetcurrency { get; set; }
        public double value { get; set; }
    }
}
