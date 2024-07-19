namespace Store
{
    public class Cart : Warehouse
    {
        private readonly IWarehouse _warehouse;

        public Cart(IWarehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public override void Add(Good good, int addingQuantity)
        {
            IReadOnlyCell goodInCart = CellsView.FirstOrDefault(cell => cell.Good == good);
            IReadOnlyCell goodInWarehouse = _warehouse.CellsView.FirstOrDefault(cell => cell.Good == good);
            
            int quantityInCart = goodInCart == null ? 0 : goodInCart.Quantity;
            int quantityInWarehouse = goodInWarehouse == null ? 0 : goodInWarehouse.Quantity;
            
            if (quantityInWarehouse < quantityInCart + addingQuantity)
                throw new ArgumentOutOfRangeException(nameof(addingQuantity));

            base.Add(good, addingQuantity);
        }

        public Order Order()
        {
            _warehouse.Remove(CellsView);
            return new Order();
        }
    }
}
