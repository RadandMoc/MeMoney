using System.ComponentModel.DataAnnotations;

namespace MeMoney.DBases
{
    public class Company
    {
        
        [Key]
        public int IdCompany1 { get; set; }
        public string CompanyName1 { get; set; }
        public string Person1 { get; set ; }
        public int NIP1 { get; set; }
        public int KRS1 { get; set; }
    }
}