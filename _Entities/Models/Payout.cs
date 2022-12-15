using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Entities.Models
{
    public  class Payout
    {
        [Column("PayoutId")]
        public Guid Id { get; set; }
        public DateTime TimestampUtc { get; set; }
        public decimal TotalPayout { get; set; }

        [ForeignKey(nameof(Bet))]
        public Guid? BetId { get; set; }
        public Bet? Bet { get; set; }

        [ForeignKey(nameof(Spin))]
        public Guid? SpinId { get; set; }
        public Spin? Spin { get; set; }
    }
}
