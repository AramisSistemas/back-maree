using backmaree.Modelsdtos.Stock;

namespace backmaree.Interfaces
{
    public interface IStockService
    {
        StockDto GetStock(); 
        IEnumerable<ProductoDto> GetProductosBase();
    }
}
