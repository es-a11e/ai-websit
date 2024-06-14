using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace DAL.Entity
{

    public class Person
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public long NationalPerson_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string HomePhoneNumber { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Nots { get; set; }

        public bool Is_he_missing { get; set; }

        //لسه مشغلتهاش    هشغلها لما اضيف الموظف ودي فايدتها تقولي الكولوم ده اتضاف امتا
        //public DateTime CreationDate {  get; set; }= DateTime.Now;

        [Required]
        public string ImageName { get; set;}


        [Required]
        [ForeignKey("Father")]
        public long ? National_Father_Id_FK { get; set; }
        [InverseProperty("Persons")]
        public Father Father { get; set; }




        [ForeignKey("Mother")]
        [Required]
        public long? National_Mother_Id_FK { get; set; }
        [InverseProperty("Persons")]
        public Mother Mother { get; set; }
    }



}
