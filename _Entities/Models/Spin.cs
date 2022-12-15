using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Entities.Models
{
    public class Spin
    {
        [Column("SpinId")]
        public Guid Id { get; set; }
        public long? SpinResult { get; set; }
        public DateTime TimestampUtc { get; set; }

        [ForeignKey(nameof(Bet))]
        public Guid? BetId { get; set; }
        public ICollection<Bet>? Bets { get; set; }
    }
}
