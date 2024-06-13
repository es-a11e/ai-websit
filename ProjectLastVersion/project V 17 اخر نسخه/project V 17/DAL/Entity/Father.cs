using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Father
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public long National_Father_Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber1 { get; set; }
        [Phone]
        public string PhoneNumber2 { get; set; }
        [Phone]
        public string HomePhoneNumber { get; set; }
        public bool Gender { get; set; } = true;

        public bool AliveOrNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string ImageName { get; set; }
        public string Nots { get; set; }

        [InverseProperty("Father")]
        public ICollection <Person> Persons { get; set; }= new HashSet<Person>();

    }
}
