using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ASP_MVC_Shop.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field cannot be empty")]
        [MinLength(5, ErrorMessage="Enter minimum 5 simbols")]
        [Display(Name="Name of products")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Display(Name= "Quantity in stock")]
        public int Count { get; set; }

    }
}
