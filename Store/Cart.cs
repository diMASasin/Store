namespace Store
{
    public class Cart : Storage
    {
        private readonly Warehouse _warehouse;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public override void Add(Good good, int quantity)
        {
            if (!_warehouse.IsGoodsEnough(good, quantity))
                throw new ArgumentOutOfRangeException(nameof(quantity));

            base.Add(good, quantity);
        }

        public Order Order() => new(_warehouse, CellsView);
    }
}
