using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Order.Entity
{
    public class OrderEntity
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }

        public int BuyQty { get; set; }

        [NotMapped]
        public float OrderAmt { get; set; }

        [NotMapped]
        public int OrderQty { get; set; }

        [NotMapped]

        public BookEntity Book { get; set; }

        [NotMapped]
        public UserEntity User { get; set; }




    }
}
