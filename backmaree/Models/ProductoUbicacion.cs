using System;
using System.Collections.Generic;

namespace backmaree.Models
{
    public partial class ProductoUbicacion
    {
        public ProductoUbicacion()
        {
            ProductoBases = new HashSet<ProductoBase>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Detalle { get; set; } = null!;

        public virtual ICollection<ProductoBase> ProductoBases { get; set; }
    }
}
