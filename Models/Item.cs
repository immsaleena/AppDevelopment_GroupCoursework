using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coursework.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Item Name is required!")]
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Manufactured Date is required!")]
        public DateTime ManufacturedDate { get; set; }
        [Required(ErrorMessage = "Expiry Date is required!")]
        public DateTime ExpiryDate { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
