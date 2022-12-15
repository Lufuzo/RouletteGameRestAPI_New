using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Entities.Models
{
    public class Bet
    {

        [Column("BetId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "bet  name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string BetOn { get; set; } = null!;

        public DateTime TimestampUtc { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "should be  positive amount.")]
        public decimal BetValue { get; set; }

        public Spin? Spin { get; set; }
        public Payout? Payout { get; set; }

    }
}
