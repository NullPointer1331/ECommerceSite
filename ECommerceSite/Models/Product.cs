using System.ComponentModel.DataAnnotations;

namespace ECommerceSite.Models
{
    /// <summary>
    /// Represents a product available for purchase.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The unique identifier for the product.
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The product category.
        /// Must be one of the following: TBD
        /// </summary>
        [Required]
        public string Category { get; set; }

        /// <summary>
        /// The sales price of the product.
        /// </summary>
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public Product()
        {
            Name = "Default";
            Category = "Other";
            Price = 0.0;
        }

        public Product(string name, string category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
        }
    }
}
