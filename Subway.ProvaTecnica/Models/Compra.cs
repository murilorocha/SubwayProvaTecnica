using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Subway.ProvaTecnica.Models
{
    public class Compra
    {
        public int ID { get; set; }

        [Required]
        [ForeignKey("Conta")]
        [Display(Name = "Conta")]
        public int ContaId { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 1)]
        public string Produtos { get; set; }

        [Required]
        public decimal Valor { get; set; }
        
        public bool Ativo { get; set; } = true;

        public virtual Conta Conta { get; set; }
    }
}
