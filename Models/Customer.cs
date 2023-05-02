using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coursework.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer Code is required!")]
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Customer mobile number is required!")]
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string CustomerType { get; set; }
    }
}
