using P3AddNewFunctionalityDotNetCore.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace P3AddNewFunctionalityDotNetCore.Models
{
    public class Cart : ICart
    {
        private readonly List<CartLine> _cartLines;

        public Cart()
        {
            _cartLines = new List<CartLine>();
        }

        public void AddItem(Product product, int quantity)
        {
            CartLine line = _cartLines.FirstOrDefault(p => p.Product.Id == product.Id);

            if (line == null)
            {
                _cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product) => _cartLines.RemoveAll(l => l.Product.Id == product.Id);

        public double GetTotalValue()
        {
            return _cartLines.Any() ? _cartLines.Sum(l => l.Product.Price) : 0;
        }

        public double GetAverageValue()
        {
            return _cartLines.Any() ? _cartLines.Average(l => l.Product.Price) : 0;
        }

        public void MarkAsOutOfStock(Product product)
        {
            // Chercher la ligne du produit dans le panier
            var line = _cartLines.FirstOrDefault(l => l.Product.Id == product.Id);

            // Si la ligne est trouvée, marquez-la comme hors stock
            if (line != null)
            {
                line.IsOutOfStock = true; // Ajoutez une propriété IsOutOfStock dans la classe CartLine
            }
        }


        public void Clear() => _cartLines.Clear();

        public IEnumerable<CartLine> Lines => _cartLines;
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool IsOutOfStock { get; set; } //Methode MarkAsOutOfStock
    }
}
