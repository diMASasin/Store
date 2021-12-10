using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    class Cart : Storage
    {
        private readonly Warehouse _warehouse;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        override public void Add(Good good, int quantity)
        {
            if (!_warehouse.IsGoodsEnough(good, quantity))
                throw new ArgumentOutOfRangeException(nameof(quantity));

            base.Add(good, quantity);
        }

        public Order Order()
        {
            return new Order(_warehouse, CellsView);
        }
    }
}
