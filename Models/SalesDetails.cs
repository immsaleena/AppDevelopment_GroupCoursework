using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coursework.Models
{
    public class SalesDetails
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "SalesID is required!")]
        [ForeignKey("Sales")]
        public int SalesID { get; set; }
        public virtual Sales Sales { get; set; }
        public string Quantity { get; set; }
        public string Amount { get; set; }
        [Required(ErrorMessage = "Item is required!")]
        [ForeignKey("Item")]
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
    }
}
