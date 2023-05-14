using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeMoney.DBases
{
    public class OfferMemAuthor
    {
        [Key, Column(Order = 0)]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }
        [Key, Column(Order = 0)]

        public int IdMemAuthor { get; set; }
        public virtual MemAuthor MemAuthor { get; set; }
    }
}
