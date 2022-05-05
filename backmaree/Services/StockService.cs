using backmaree.Interfaces;
using backmaree.Models;
using backmaree.Modelsdtos.Stock;
using Microsoft.Data.SqlClient;
using System.Data;
namespace backmaree.Services
{
    public class StockService : IStockService
    {
        private readonly IStoreProcedure _storeProcedure;
        private readonly mareeContext _context;

        public StockService(IStoreProcedure storeProcedure, mareeContext context)
        {
            _storeProcedure = storeProcedure;
            _context = context;
        }
        public StockDto GetStock()
        {
            try
            {
                DataSet ds = _storeProcedure.SpWhithDataSetPure("ProductosGet");
                List<ProductoDto> productos = new();
                List<ProductodetalleDto> detalles = new();
                DataTable dtProductos = new();
                DataTable dtdetalles = new();
                dtProductos = ds.Tables[0];
                dtdetalles = ds.Tables[1];
                foreach (DataRow row in dtProductos.Rows)
                {
                    productos.Add(new ProductoDto()
                    {
                        Id = (long)row["Id"],
                        Codigo = row["Codigo"].ToString(),
                        Detalle = row["Detalle"].ToString(),
                        Ubicacion = (int)row["Ubicacion"],
                        UbicacionStr = row["UbicacionStr"].ToString(),
                        Rubro = (int)row["Rubro"],
                        RubroStr = row["RubroStr"].ToString(),
                        Costo = (decimal)row["Costo"],
                        Iva = (int)row["Iva"],
                        IvaDec = (decimal)row["IvaDec"],
                        Internos = (decimal)row["Internos"],
                        Tasa = (decimal)row["Tasa"],
                        Stock = (decimal)row["Stock"],
                        Compuesto = (bool)row["Compuesto"],
                        Precio = (decimal)row["Precio"],
                        Tipo = row["Tipo"].ToString()
                    });
                }
                foreach (DataRow rowDetalles in dtdetalles.Rows)
                {
                    detalles.Add(new ProductodetalleDto()
                    {
                        Id = (long)rowDetalles["Id"],
                        ProductoFk = (long)rowDetalles["ProductoFk"],
                        ProductoDetalleFk = (long)rowDetalles["ProductoDetalleFk"],
                        Cantidad = (decimal)rowDetalles["Cantidad"],
                        Codigo = rowDetalles["Codigo"].ToString(),
                        Detalle = rowDetalles["Detalle"].ToString(),
                        Precio = (decimal)rowDetalles["Precio"]
                    });
                };

                StockDto lst = new();
                lst.Producto = productos;
                lst.Detalles = detalles;
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ProductoDto> GetProductosBase()
        {
            throw new NotImplementedException();
        }
    }
}
