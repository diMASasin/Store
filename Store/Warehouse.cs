namespace Store
{
    public class Warehouse : Storage
    {
        public bool IsGoodsEnough(Good good, int quantity)
        {
            IReadOnlyCell cell = CellsView.FirstOrDefault(cell => cell.Good == good);
            return cell != null && cell.Quantity >= quantity;
        }
    }
}
