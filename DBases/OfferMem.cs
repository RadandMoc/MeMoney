using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeMoney.DBases
{
    public class OfferMem
    {
        [Key]
        public int OfferMemId { get; set; }

        [Key, Column(Order = 0)]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }

        [Key, Column(Order = 1)]

        public int MemId { get; set; }
        public virtual Mem Mem { get; set; }

    }
}
