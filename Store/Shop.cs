using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Shop
    {
        private readonly Cart _cart;

        public Shop(Warehouse warehouse)
        {
            _cart = new Cart(warehouse);
        }

        public Cart GetCart()
        {
            return _cart;
        }
    }
}
