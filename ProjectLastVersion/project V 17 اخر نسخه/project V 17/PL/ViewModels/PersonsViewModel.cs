using DAL.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace PL.Models
{
    public class PersonsViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "National Person Id Is Required")]
        public long NationalPerson_Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        public string HomePhoneNumber { get; set; }
        [Required(ErrorMessage = "Gender Is Required")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Date Of Birth Is Required")]
        public DateTime DateOfBirth { get; set; }

        //[Required(ErrorMessage = "Image Is Required")]
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public string Nots { get; set; }

        public bool Is_he_missing { get; set; }


        //public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Father national number Is Required")]
        [ForeignKey("Father")]
        public long? National_Father_Id_FK { get; set; }
        [InverseProperty("Persons")]
        public Father Father { get; set; }




        [ForeignKey("Mother")]
        [Required(ErrorMessage = "Mother national number Is Required")]
        public long? National_Mother_Id_FK { get; set; }
        [InverseProperty("Persons")]
        public Mother Mother { get; set; }
    }
}
