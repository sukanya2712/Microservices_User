using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookManagementCQRS.Entity
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }


        [Required]
        [Range(1, 100)]
        public float Price { get; set; }


        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        public string AddedBy { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Addedon { get; set; }


        public DateTime CreatedAt { get; set; }
    }
}
