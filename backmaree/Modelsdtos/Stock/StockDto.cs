namespace backmaree.Modelsdtos.Stock
{
    public class StockDto
    {
        public IEnumerable<ProductoDto> Productos { get; set; }
        public IEnumerable<ProductoBaseDto> ProductoBases { get; set; }
    }
}
