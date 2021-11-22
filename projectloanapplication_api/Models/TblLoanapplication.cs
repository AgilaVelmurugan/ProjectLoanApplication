using System;
using System.Collections.Generic;

#nullable disable

namespace projectloanapplication_api.Models
{
    public partial class TblLoanapplication
    {
        public string LoanApplicationNumber { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternateNumber { get; set; }
        public string EmailId { get; set; }
        public string PanNumber { get; set; }
        public string AadharNumber { get; set; }
        public string UserAddress { get; set; }
        public string LoanType { get; set; }
        public string JobType { get; set; }
        public double AnnualIncome { get; set; }
        public double LoanAmount { get; set; }
        public double InterestOnYear { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool RecordStatus { get; set; }
    }
}
