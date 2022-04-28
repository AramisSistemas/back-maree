using System;
using System.Collections.Generic;

namespace backmaree.Models
{
    public partial class ProductoIva
    {
        public ProductoIva()
        {
            ProductoBases = new HashSet<ProductoBase>();
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        public decimal Tasa { get; set; }

        public virtual ICollection<ProductoBase> ProductoBases { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
