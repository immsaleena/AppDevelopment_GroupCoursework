using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coursework.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Item is required!")]
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public string Quantity { get; set; }
    }
}
