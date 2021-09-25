using System;
using System.ComponentModel.DataAnnotations;

namespace Paychecks.Api.Models.Employee
{
    public class CreateEmployeeCommand
    {
        [Required(ErrorMessage = "The {0} must be supplied")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public string Sector { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public double GrossSalary { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public DateTime AdmissionDate { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public bool HealthInsuranceDiscount { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public bool DentalInsuranceDiscount { get; set; }

        [Required(ErrorMessage = "The {0} must be supplied")]
        public bool TransportationVoucherDiscount { get; set; }
    }
}