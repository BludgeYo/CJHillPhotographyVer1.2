using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CJHillPhotography.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageName { get; set; }

        [Required]
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] ImageData { get; set; }
    }

    public class CartItem
    {
        [Key] // Add this annotation to specify CartItemId as the primary key
        public int CartItemId { get; set; }

        public int ImageId { get; set; }

        public int Quantity { get; set; }

        // Add navigation property to reference the Image
        public virtual Image Image { get; set; }
    }

    // Correct the class name to User (singular)
    public class User
    {
        [Key] // Add this annotation to specify UserID as the primary key
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
    }


}
