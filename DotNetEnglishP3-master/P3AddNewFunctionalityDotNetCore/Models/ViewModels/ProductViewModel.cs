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

        [Required(ErrorMessageResourceName = "MissingQuantity", ErrorMessageResourceType = (typeof(Resources.Models.Services.ProductService)))]//Quantity obligatoire
        [RegularExpression(@"^[0-9]+$", ErrorMessageResourceName = "StockNotAnInteger", ErrorMessageResourceType = (typeof(Resources.Models.Services.ProductService)))] //Price doit est un nombre
        [Range(1, int.MaxValue, ErrorMessageResourceName = "StockNotGreaterThanZero", ErrorMessageResourceType = (typeof(Resources.Models.Services.ProductService)))] //Price doit etre superieur a 0 (1 minimum)
        public string Quantity { get; set; } //Change "stock" to "quantity"

        [Required(ErrorMessageResourceName = "MissingPrice", ErrorMessageResourceType = (typeof(Resources.Models.Services.ProductService)))]//Price obligatoire
        [RegularExpression(@"^\s*[0-9]\d*([,.]\d+)?\s*$", ErrorMessageResourceName = "PriceNotANumber", ErrorMessageResourceType = (typeof(Resources.Models.Services.ProductService)))] //DataType = Currency : Nombre obligatoire
        [Range(0.01, double.MaxValue, ErrorMessageResourceName = "PriceNotGreaterThanZero", ErrorMessageResourceType = (typeof(Resources.Models.Services.ProductService)))] //Price doit etre superieur a 0 (ou un decimal entre 0 et 1)
        public string Price { get; set; }
    }
}
