namespace Store;

public interface IReadOnlyCell
{
    public Good Good { get; }
    public int Quantity { get; }
}