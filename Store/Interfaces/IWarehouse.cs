namespace Store;

public interface IWarehouse
{
    public IReadOnlyList<IReadOnlyCell> CellsView { get; }
    void Remove(IReadOnlyList<IReadOnlyCell> cartCells);
}