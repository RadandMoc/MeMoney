using System.ComponentModel.DataAnnotations;

namespace MeMoney.DBases
{
    public class OfferMemAuthor
    {
        [Key]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }
   
        public int MemId { get; set; }
        public virtual MemAuthor Mem { get; set; }
    }
}
