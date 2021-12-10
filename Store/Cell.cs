using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Cell : IReadOnlyCell
    {
        public Good Good { get; private set; }
        public int Quantity { get; private set; }

        public Cell(Good good, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            Good = good;
            Quantity = quantity;
        }

        public void Merge(IReadOnlyCell newCell)
        {
            if (Good != newCell.Good)
                throw new InvalidOperationException(nameof(newCell));

            Quantity += newCell.Quantity;
        }

        public void Remove(IReadOnlyCell cell)
        {
            if (Good != cell.Good)
                throw new InvalidOperationException(nameof(cell));

            Quantity -= cell.Quantity;
        }
    }

    interface IReadOnlyCell
    {
        public Good Good { get; }
        public int Quantity { get; }
    }
}
