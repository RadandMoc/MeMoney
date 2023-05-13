using System.ComponentModel.DataAnnotations;

namespace MeMoney.DBases
{
    public class OfferMem
    {

        [Key]
        public int OfferId { get; set; }
        public virtual Offer Offer { get; set; }
        public int MemAuthorId { get; set; }
        public virtual MemAuthor MemAuthor { get; set; }

    }
}
