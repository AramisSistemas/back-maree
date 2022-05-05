namespace backmaree.Modelsdtos.Stock
{
    public class StockDto
    {
        public IEnumerable<ProductoDto> Producto { get; set; }  
        public IEnumerable<ProductodetalleDto> Detalles { get; set; }
    }
}
