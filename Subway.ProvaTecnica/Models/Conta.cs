using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Subway.ProvaTecnica.Models
{
    public class Conta
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Nome { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        
        public bool Ativo { get; set; } = true;

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
