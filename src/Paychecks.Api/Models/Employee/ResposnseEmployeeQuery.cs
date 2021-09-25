using System;

namespace Paychecks.Api.Models.Employee
{
    public class ResposnseEmployeeQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string Sector { get; set; }
        public double GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool HealthInsuranceDiscount { get; set; }
        public bool DentalInsuranceDiscount { get; set; }
        public bool TransportationVoucherDiscount { get; set; }
    }
}