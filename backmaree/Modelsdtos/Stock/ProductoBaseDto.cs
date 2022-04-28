namespace backmaree.Modelsdtos.Stock
{
    public class ProductoBaseDto
    {
        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Detalle { get; set; } = null!;
        public int Ubicacion { get; set; }
        public string UbicacionStr { get; set; } = null!;
        public int Rubro { get; set; }
        public string RubroStr { get; set; } = null!;
        public decimal Costo { get; set; }
        public int Iva { get; set; }
        public decimal IvaDec { get; set; }
        public decimal Internos { get; set; }
        public decimal Tasa { get; set; }
        public decimal Stock { get; set; }
        public decimal Precio { get; set; }
        // for Producto Detalle
        public long ProductoFk { get; set; }
        public long ProductobaseFk { get; set; }
    }
}
