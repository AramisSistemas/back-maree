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
        public StockDto GetProductos()
        {
            try
            {
                DataSet ds = _storeProcedure.SpWhithDataSetPure("ProductosGet");
                List<ProductoDto> productos = new();
                List<ProductoBaseDto> productoBases = new();
                DataTable dtProductos = new();
                DataTable dtProductosBase = new();
                dtProductos = ds.Tables[0];
                dtProductosBase = ds.Tables[1];
                foreach (DataRow row in dtProductos.Rows)
                {
                    productos.Add(new ProductoDto()
                    {
                        Id = (long)row["Id"],
                        Codigo = row["Codigo"].ToString(),
                        Detalle = row["Detalle"].ToString(),
                        Rubro = (int)row["Rubro"],
                        RubroStr = row["RubroStr"].ToString(),
                        Costo = (decimal)row["Costo"],
                        Iva = (int)row["Iva"],
                        IvaDec = (decimal)row["IvaDec"],
                        Precio = (decimal)row["Precio"],
                        Tasa = (decimal)row["Tasa"]
                    });
                }
                foreach (DataRow rowBase in dtProductosBase.Rows)
                {
                    productoBases.Add(new ProductoBaseDto()
                    {
                        Id = (long)rowBase["Id"],
                        Codigo = rowBase["Codigo"].ToString(),
                        Detalle = rowBase["Detalle"].ToString(),
                        Rubro = (int)rowBase["Rubro"],
                        RubroStr = rowBase["RubroStr"].ToString(),
                        Costo = (decimal)rowBase["Costo"],
                        Iva = (int)rowBase["Iva"],
                        IvaDec = (decimal)rowBase["IvaDec"],
                        Precio = (decimal)rowBase["Precio"],
                        Internos = (decimal)rowBase["Internos"],
                        ProductobaseFk = (long)rowBase["ProductobaseFk"],
                        ProductoFk = (long)rowBase["ProductoFk"],
                        Stock = (decimal)rowBase["Stock"],
                        Ubicacion = (int)rowBase["Ubicacion"],
                        UbicacionStr = rowBase["UbicacionStr"].ToString(),
                        Tasa = (decimal)rowBase["Tasa"]
                    });
                };

                StockDto lst = new();
                lst.Productos = productos;
                lst.ProductoBases = productoBases;
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ProductoBaseDto> GetProductosBase()
        {
            throw new NotImplementedException();
        }
    }
}
