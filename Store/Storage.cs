using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    class Storage
    {
        protected readonly List<Cell> Cells = new List<Cell>();

        public IReadOnlyList<IReadOnlyCell> CellsView => Cells;

        virtual public void Add(Good good, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException(nameof(quantity));

            Cell cell = Cells.FirstOrDefault(cell => cell.Good == good);

            if (cell != null)
                cell.Merge(new Cell(good, quantity));
            else
                Cells.Add(new Cell(good, quantity));
        }
    }
}
