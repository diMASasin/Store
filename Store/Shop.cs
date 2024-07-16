namespace Store
{
    public class Shop
    {
        private readonly Cart _cart;

        public Shop(Warehouse warehouse)
        {
            _cart = new Cart(warehouse);
        }

        public Cart GetCart() => _cart;
    }
}
