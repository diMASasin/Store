using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    class Warehouse : Storage
    {
        public void Remove(IReadOnlyList<IReadOnlyCell> cartCells)
        {
            foreach (var cell in Cells)
            {
                foreach (var cartCell in cartCells)
                {
                    if (cell.Good != cartCell.Good)
                        break;

                    if (cell.Quantity < cartCell.Quantity)
                        throw new ArgumentOutOfRangeException(nameof(cartCell.Quantity));

                    cell.Remove(cartCell);
                }
            }
        }

        public bool IsGoodsEnough(Good good, int quantity)
        {
            IReadOnlyCell cell = CellsView.FirstOrDefault(cell => cell.Good == good);
            return cell != null && cell.Quantity >= quantity;
        }
    }
}
