using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerRegisterDatabase.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ett namn måste anges")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ett efternamn måste anges")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LastName { get; set; }

        [Range(0, 120, ErrorMessage = "Åldern får bara vara mellan 0-120 år")]
        [Required(ErrorMessage = "Du måste ange en ålder")]
        public int Age { get; set; }

        
        [Required(ErrorMessage = "En email adress måste anges")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Ett kön måste anges")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Gender { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateEdited { get; set; }


    }
}
