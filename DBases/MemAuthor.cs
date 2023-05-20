using System.ComponentModel.DataAnnotations;

namespace MeMoney.DBases
{
    public class MemAuthor
    {

        [Key]
        public int IdMemAuthor { get; set; }
        public string NickName { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set ; }
        public string BankAccountNumber { get ; set; }

        public ICollection<OfferMemAuthor> ?OffersMemAuthor { get; set; }

        public MemAuthor() 
        {

        }

    }
}
