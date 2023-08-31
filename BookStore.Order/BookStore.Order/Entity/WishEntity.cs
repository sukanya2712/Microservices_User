using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Order.Entity
{
    public class WishEntity
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishID { get; set; }


        [Required(ErrorMessage = "UserID is required.")]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "UserID must be a positive integer.")]
        public int UserID { get; set; }


        [Required(ErrorMessage = "BookID is required.")]
        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "BookID must be a positive integer.")]
        public int BookID { get; set; }



        [NotMapped]
        public BookEntity Book { get; set; }

        [NotMapped]
        public UserEntity User { get; set; }
    }
}
