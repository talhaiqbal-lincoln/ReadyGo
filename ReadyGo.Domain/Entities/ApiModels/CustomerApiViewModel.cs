using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class CustomerApiViewModel
    {
        public Guid? Id { get; set; }
        public string BusinessName { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Address is required")]
        public string Address1 { get; set; }

        [Display(Name = "Address line 2")]
        public string Address2 { get; set; }

        [StringLength(LabelConstants.CityMaxLength)]
        public string City { get; set; }
        public string CNIC { get; set; }

        [StringLength(LabelConstants.CityMaxLength)]
        public string Province { get; set; }

        [Remote("CheckDupEmail", "Customer", HttpMethod = "POST", ErrorMessage = "Customer already exists.")]
        //[EmailAddress(ErrorMessage = ValidationErrorConstants.NotValid)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Image { get; set; }
        public double Balance { get; set; }
        public string AxCode { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }


        public List<DiscountApiViewModel> Discounts { get; set; }

    }
}