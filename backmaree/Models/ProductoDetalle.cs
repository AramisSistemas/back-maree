using System;
using System.Collections.Generic;

namespace backmaree.Models
{
    public partial class ProductoDetalle
    {
        public int Id { get; set; }
        public long ProductoFk { get; set; }
        public long ProductobaseFk { get; set; }
        public decimal Cantidad { get; set; }

        public virtual Producto ProductoFkNavigation { get; set; } = null!;
        public virtual ProductoBase ProductobaseFkNavigation { get; set; } = null!;
    }
}
