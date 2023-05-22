using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeMoney.DBases
{
    public class OfferMem
    {
        [Key]
        public int OfferMemId { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }

        [ForeignKey("Mem")]

        public int MemId { get; set; }
        public virtual Mem Mem { get; set; }

    }
}
