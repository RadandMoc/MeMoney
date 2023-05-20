using System.ComponentModel.DataAnnotations;

namespace MeMoney.DBases
{
    public class Offer
    {

        [Key]
        public int Id { get; set; }
        public int CompanyIdCompany1 { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal AdditionalSalary { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Condition { get; set; }
        public string AdditionalCondition { get; set ; }
        public bool IfPaid { get; set; }
        public decimal MaximalSalary1 { get; set; }
        public ICollection<OfferMem> ?MemOffers { get; set; }
        public ICollection<OfferMemAuthor> ?OffersMemAuthor { get; set; }


        public Offer() 
        {
        }

    }
}
