using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class View
    {
        public void ShowStorage(IReadOnlyList<IReadOnlyCell> cells)
        {
            Console.WriteLine("Warehouse:");
            foreach (var cell in cells)
            {
                Console.WriteLine(cell.Good.Name + ": " + cell.Quantity);
            }
            Console.WriteLine();
        }
    }
}
