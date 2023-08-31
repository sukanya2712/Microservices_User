using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookManagementCQRS.Model.Command
{
    public class InserUpdateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
