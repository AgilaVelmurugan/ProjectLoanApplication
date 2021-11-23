using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace projectloanapplication.Models
{
    public partial class TblLoanapplication
    {
        public string LoanApplicationNumber { get; set; }
        [Required (ErrorMessage ="Please Enter Full Name ")]
        [Display (Name ="Full Name")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string FullName { get; set; }
        [Required (ErrorMessage = "Please Choose Date of Birth")]
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required (ErrorMessage ="Please Enter Phone Number")]
        [Display(Name ="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
 
        public string PhoneNumber { get; set; }
        [Display(Name ="Alternate Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string AlternateNumber { get; set; }
        [Display(Name ="Email ID")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="Not a valid Email Address")]
        public string EmailId { get; set; }
        [Required (ErrorMessage ="Please enter Pan Number")]
        [Display(Name ="Pan Number")]
        [RegularExpression(@"([A-Z]){5}([0-9]){4}([A-Z]){1}$",ErrorMessage ="Not a valid Pan Number")]
        public string PanNumber { get; set; }
        [Required (ErrorMessage ="please Enter Aadhar Number ")]
        [Display(Name ="Aadhar Number")]
        [RegularExpression(@"^[2-9]{1}[0-9]{3}(\s)?[0-9]{4}(\s)?[0-9]{4}$", ErrorMessage ="Not a valid Aadhar Number")]
        public string AadharNumber { get; set; }
        [Display(Name ="Address")]
        [RegularExpression(@"[0-9a-zA-Z #,-]+",ErrorMessage ="Not a valid address")]
        public string UserAddress { get; set; }
        [Required (ErrorMessage ="Please Choose Loan Type")]
        [Display(Name ="Loan Type")]
        public string LoanType { get; set; }
        [Required (ErrorMessage = "Please Choose Job Type")]
        [Display(Name ="Job Type")]
        public string JobType { get; set; }
        [Required (ErrorMessage ="Please Enter Annual Income")]
        [Display(Name ="Annual Income")]
        [RegularExpression(@"[0-9]+", ErrorMessage ="Not a valid Income")]
        public double AnnualIncome { get; set; }
        [Required (ErrorMessage ="Please Enter Loan Amount")]
        [Display(Name ="Loan Amount")]
        [RegularExpression(@"[0-9]+", ErrorMessage = "Not a valid amount")]
        public double LoanAmount { get; set; }
        [Display(Name ="Annual interest")]
        public double InterestOnYear { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public bool RecordStatus { get; set; }
    }
}
