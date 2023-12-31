﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Order.Entity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Genre { get; set; }



        
        public int BookQty { get; set; }

        public float DiscountedPri { get; set; }

        public float ListPrice { get; set; }

        public float ratings { get; set; }  
    }
}
