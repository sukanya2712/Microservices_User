using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BookStore.User.Entity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required(ErrorMessage = "First Name {0} is required")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Minimum length should be  4 character and Maximum length is 50")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name {0} is required")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Minimum length should be 4 character and Maximum length is 50")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email {0} is required")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password {0} is required")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

       
        public string Address { get; set; }
       

    }
}
