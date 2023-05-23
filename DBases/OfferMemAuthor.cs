using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeMoney.DBases
{
    public class OfferMemAuthor
    {
        [Key]

        public int OfferMemAuthorId { get; set; }

        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }

        [ForeignKey("MemAuthor")]

        public int IdMemAuthor { get; set; }
        public virtual MemAuthor MemAuthor { get; set; }
    }
}
