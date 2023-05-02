using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coursework.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required!")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Vendor name is required!")]
        public string VendorName { get; set; }
        [Required(ErrorMessage = "Bill number is required!")]
        public string BillNumber { get; set; }
    }
}
