using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coursework.Models
{
    public class PurchaseDetails
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "PurchaseID is required!")]
        [ForeignKey("Purchase")]
        public int PurchaseID { get; set; }
        public virtual Purchase Purchase { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }
        [Required(ErrorMessage = "Item is required!")]
        [ForeignKey("Item")]
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
    }
}
