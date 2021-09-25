using System;

namespace Paychecks.Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Sector { get; set; }
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool HealthInsuranceDiscount { get; set; }
        public bool DentalInsuranceDiscount { get; set; }
        public bool TransportationVoucherDiscount { get; set; }
    }
}