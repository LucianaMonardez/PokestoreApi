using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPokestoreApi.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string image { get; set; }
        [Required]
        [StringLength(20)]
        public string title { get; set; }
        [Required]
        public int price { get; set; }
        public string description { get; set; }
    }
}
