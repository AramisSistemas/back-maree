using AutoMapper;
using backmaree.Helpers;
using backmaree.Interfaces;
using backmaree.Models;
using backmaree.Modelsdtos.Stock;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backmaree.Controllers
{
    //[Authorize]
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class StockController : Controller
    {
        private readonly IGenericService<Producto> _productoGenService;
        private readonly IGenericService<ProductoDetalle> _productoDetalleGenService;
        private readonly IGenericService<Producto> _productoBaseGenService;
        private readonly IGenericService<ProductoIva> _ivaGenService;
        private readonly IGenericService<ProductoRubro> _rubroGenService;
        private readonly IGenericService<ProductoUbicacion> _ubicacionGenService;
        private readonly ILoggService _loggService;
        private readonly IMapper _mapper;
        private readonly SecurityService _securityService;
        private readonly string _userName;
        private readonly IStockService _stockService;
        public StockController(
            IGenericService<Producto> productoGenService,
            IGenericService<ProductoDetalle> productoDetalleGenService,
            IGenericService<Producto> productoBaseGenService,
            IGenericService<ProductoIva> ivaGenService,
            IGenericService<ProductoRubro> rubroGenService,
            IGenericService<ProductoUbicacion> ubicacionGenService,
            ILoggService loggService,
            IMapper mapper,
            SecurityService securityService,
            IStockService stockService
            )
        {
            _productoGenService = productoGenService;
            _productoDetalleGenService = productoDetalleGenService;
            _productoBaseGenService = productoBaseGenService;
            _ivaGenService = ivaGenService;
            _rubroGenService = rubroGenService;
            _ubicacionGenService = ubicacionGenService;
            _loggService = loggService;
            _mapper = mapper;
            _securityService = securityService;
            _userName = _securityService.GetUserAuthenticated();
            _stockService = stockService;
        }


        //ABM PRODUCTOS BASE
        [HttpPost("AltaProductoBase")]
        public IActionResult AltaProductoBase([FromForm] ProductoDto model)
        { 
            try
            {
                Producto? productobase = _mapper.Map<Producto>(model);
                _productoBaseGenService.Add(productobase);
                _loggService.Log($"AltaProductoBase {model.Detalle}", "Stock", "Add", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error AltaProductoBase {model.Detalle}", "Stock", "Add", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("UpdateProductoBase")]
        public IActionResult UpdateProductoBase([FromForm] ProductoDto model)
        {
            try
            {
                Producto? productobase = _mapper.Map<Producto>(model);
                _productoBaseGenService.Update(productobase);
                _loggService.Log($"UpdateProductoBase {model.Detalle}", "Stock", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error UpdateProductoBase {model.Detalle}", "Stock", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteProductoBase")]
        public IActionResult DeleteProductoBase([FromForm] ProductoDto model)
        {
            try
            {
                Producto? productobase = _mapper.Map<Producto>(model);
                _productoBaseGenService.Delete(productobase.Id);
                _loggService.Log($"DeleteProductoBase {model.Detalle}", "Stock", "Delete", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error DeleteProductoBase {model.Detalle}", "Stock", "Delete", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetProductoBase")]
        public IActionResult GetProductoBase()
        {
            try
            {
                var data = _stockService.GetProductosBase();
                return Ok(data);
            }
            catch (Exception ex)
            { 
                return BadRequest(new { message = ex.Message });
            }
        }

        //ABM PRODUCTOS
        [HttpPost("AltaProducto")]
        public IActionResult AltaProducto([FromForm] ProductoDto model)
        {
            try
            {
                Producto? producto = _mapper.Map<Producto>(model);
                _productoGenService.Add(producto);
                _loggService.Log($"AltaProducto {model.Detalle}", "Stock", "Add", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error AltaProducto {model.Detalle}", "Stock", "Add", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetProductos")]
        public IActionResult GetProductos()
        {
            try
            {
                var data = _stockService.GetStock();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        //ABM PRODUCTOS DETALLE
        [HttpPost("AltaProductoDetalle")]
        public IActionResult AltaProductoDetalle([FromForm] ProductodetalleDto model)
        {
            try
            {
                ProductoDetalle? productodetalle = _mapper.Map<ProductoDetalle>(model);
                _productoDetalleGenService.Add(productodetalle);
                _loggService.Log($"AltaProductoDetalle {model.ProductoDetalleFk} sobre {model.ProductoFk}", "Stock", "Add", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error AltaProductoDetalle {model.ProductoDetalleFk} sobre {model.ProductoFk}", "Stock", "Add", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("UpdateProductoDetalle")]
        public IActionResult UpdateProductoDetalle([FromForm] ProductodetalleDto model)
        {
            try
            {
                ProductoDetalle? productodetalle = _mapper.Map<ProductoDetalle>(model);
                _productoDetalleGenService.Add(productodetalle);
                _loggService.Log($"UpdateProductoDetalle {model.ProductoDetalleFk} sobre {model.ProductoFk}", "Stock", "Update", _userName);
                return Ok("Correcto");
            }
            catch (Exception ex)
            {
                _loggService.Log($"Error UpdateProductoDetalle {model.ProductoDetalleFk} sobre {model.ProductoFk}", "Stock", "Update", _userName);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        #region Auxiliares 
        [HttpGet]
        [Route("GetIvas")]
        public IActionResult GetIvas()
        {
            IEnumerable<ProductoIva>? data = _ivaGenService.Get();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetRubros")]
        public IActionResult GetRubros()
        {
            IEnumerable<ProductoRubro>? data = _rubroGenService.Get();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetUbicaciones")]
        public IActionResult GetUbicaciones()
        {
            IEnumerable<ProductoUbicacion>? data = _ubicacionGenService.Get();
            return Ok(data);
        }
        #endregion

    }
}
