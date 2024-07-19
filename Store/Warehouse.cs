namespace Store
{
    public class Warehouse : IWarehouse
    {
        private readonly List<Cell> _cells = new();

        public IReadOnlyList<IReadOnlyCell> CellsView => _cells;
        
        public virtual void Add(Good good, int addingQuantity)
        {
            if (addingQuantity < 1)
                throw new ArgumentOutOfRangeException(nameof(addingQuantity));
          
            Cell cell = _cells.FirstOrDefault(cell => cell.Good == good);

            if (cell != null)
                cell.Merge(new Cell(good, addingQuantity));
            else
                _cells.Add(new Cell(good, addingQuantity));
        }
        
        public void Remove(IReadOnlyList<IReadOnlyCell> cartCells)
        {
            foreach (var cell in _cells)
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
    }
}
