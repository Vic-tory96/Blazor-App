using ContactBookModel.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookModels

{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "FirstName must be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="LastName must be provided")]
        public string LastName { get; set; }

        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "gmail.com", ErrorMessage = "Only gmail.com and yahoo.com is allowed")]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

         [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public string Occupation { get;set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
    }
}
