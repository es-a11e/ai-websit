using DAL.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace PL.Models
{
    public class FatherViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "National Father Id Is Required")]
        public long National_Father_Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string HomePhoneNumber { get; set; }
        public bool Gender { get; set; } = true;

        public bool AliveOrNo { get; set; }
        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Date Of Birth  Is Required")]
        public DateTime DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Image Is Required")]
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public string Nots { get; set; }

        [InverseProperty("Father")]
        public ICollection<Person> Persons { get; set; } = new HashSet<Person>();

    }
}
