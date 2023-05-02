using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coursework.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required!")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Customer is required!")]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [Required(ErrorMessage = "Bill Number is required!")]
        public string BillNumber { get; set; }
    }
}
