namespace backmaree.Modelsdtos.Stock
{
    public class ProductodetalleDto
    {
        public long Id { get; set; }
        public long ProductoFk { get; set; }
        public long ProductoDetalleFk { get; set; }
        public decimal Cantidad { get; set; }
        public string Codigo { get; set; }
        public string Detalle { get; set; }
        public decimal Precio { get; set; }

    }
}
