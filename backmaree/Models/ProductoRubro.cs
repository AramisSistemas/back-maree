using System;
using System.Collections.Generic;

namespace backmaree.Models
{
    public partial class ProductoRubro
    {
        public ProductoRubro()
        {
            ProductoBases = new HashSet<ProductoBase>();
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public string Detalle { get; set; } = null!;

        public virtual ICollection<ProductoBase> ProductoBases { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
