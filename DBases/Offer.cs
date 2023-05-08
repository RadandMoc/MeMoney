﻿namespace MeMoney.DBases
{
    public class Offer
    {
        

        public int Id { get; set; }
        public Company Company { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal AdditionalSalary { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public string Condition { get; set; }
        public string AdditionalCondition { get; set ; }
        public bool IfPaid { get; set; }
        public decimal MaximalSalary1 { get; set; }



    }
}
