namespace backmaree.Modelsdtos.Stock
{
    public class ProductoDto
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
        public bool Compuesto { get; set; }
        public decimal Precio { get; set; }
        public string Tipo { get; set; } 
    }
}
