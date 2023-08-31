using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Stock
    {
        [Column("StockId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? CantidadReal { get; set; }
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string CantidadIdeal { get; set; }
        public string CantidadMinima { get; set; }
        public string CantidadAlarma { get; set; }
        public string FechaIngreso { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
