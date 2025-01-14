using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P3AddNewFunctionalityDotNetCore.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "MissingName", ErrorMessageResourceType = (typeof(Resources.Models.Services.ProductService)))]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        [Required(ErrorMessage = "MissingQuantity")] //Quantity obligatoire
        [Range(1, int.MaxValue, ErrorMessage = "QuantityNotGreaterThanZero")] //Price doit etre superieur a 0 (1 minimum)
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "QuantityNotAnInteger")] //Price doit est un nombre
        public string Quantity { get; set; } //Change "stock" to "quantity"

        [Required(ErrorMessage = "MissingPrice")] //Price obligatoire
        [Range(0.01, double.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")] //Price doit etre superieur a 0 (ou un decimal entre 0 et 1)
        [DataType(DataType.Currency, ErrorMessage = "PriceNotANumber")] //DataType = Currency : Nombre obligatoire
        public string Price { get; set; }
    }
}
