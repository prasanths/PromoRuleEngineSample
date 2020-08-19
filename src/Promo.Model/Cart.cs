using System;
using System.Collections.Generic;
using System.Text;

namespace Promo.Model
{
    public class Cart
    {
        public Guid Id { get; set; }
        public IList<CartItem> CartItems { get; set; }
    }

    public class CartItem {

        public Item Item { get; set; }
        public int Count { get; set; }
        public bool PromoApplied { get; set; }
    }
}
