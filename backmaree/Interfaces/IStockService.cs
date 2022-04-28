using backmaree.Modelsdtos.Stock;

namespace backmaree.Interfaces
{
    public interface IStockService
    {
        IEnumerable<ProductoBaseDto> GetProductosBase();
        StockDto GetProductos();
    }
}
