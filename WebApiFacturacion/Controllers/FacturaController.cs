using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services.Interfaces;
using WebApiFacturacion.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFacturaServicio _facturaServicio;
        public FacturaController(IFacturaServicio facturaServicio)
        {
            _facturaServicio = facturaServicio;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = _facturaServicio.GetFacturas();
                if (lst == null)
                {
                    return Problem(detail: "no hay facturas", statusCode: 500);
                }
                return Ok(new { mensaje = "facturas obtenidos con éxito", datos = lst });
            }
            catch (Exception)
            {
                return Problem(detail: "Error al acceder a datos", statusCode: 500);
            }
        }

        // GET: api/<FacturaController>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var art = _facturaServicio.GetFacturaById(id);
                return Ok(new { mensaje = "factura obtenida con éxito", datos = art });
            }
            catch (Exception)
            {
                return Problem(detail: "Error al acceder a datos", statusCode: 500);
            }
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post(FacturaDTO dto)
        {
            if(dto == null)
                return BadRequest(new { mensaje = "La factura no puede ser nula" });
            try
            {

                Factura nuevaFactura = new Factura
                {
                    NroFactura = 0,
                    Fecha = dto.Fecha,
                    FormaPago = new FormaPago { id = dto.IdFormaPago },
                    Cliente = new Cliente { Id = dto.IdCliente },
                    Detalle = dto.Detalle.Select(d => new DetalleFactura
                        {
                        idDetalleFactura = 0,
                        Articulo = new Articulo { Id_articulo = d.IdArticulo },
                            cantidad = d.Cantidad,
                            precio = d.Precio,
                        }).ToList()
                }
                ;
                bool resutl = _facturaServicio.SaveFactura(nuevaFactura);
                if (resutl)
                {
                    return Ok(new { mensaje = "factura creada con éxito", Factura = nuevaFactura });
                }
                else
                {
                    return Problem(detail: "No se ha podido crear la factura", statusCode: 500);
                }
            }
            catch (Exception ex)
            {
                return Problem(detail: "Error interno al crear la factura", statusCode: 500);
            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] FacturaDTO dto )
        {
            if (dto == null)
                return BadRequest(new { mensaje = "La factura no puede ser nula" });
            try
            {
                Factura nuevaFactura = new Factura
                {
                    NroFactura= id,
                    Fecha = dto.Fecha,
                    FormaPago = new FormaPago { id = dto.IdFormaPago },
                    Cliente = new Cliente { Id = dto.IdCliente },
                    Detalle = dto.Detalle.Select(d => new DetalleFactura
                    {
                        idDetalleFactura = d.IdDetalleFactura,
                        Articulo = new Articulo { Id_articulo = d.IdArticulo },
                        cantidad = d.Cantidad,
                        precio = d.Precio,
                    }).ToList()
                }
                ;
                bool result = _facturaServicio.SaveFactura(nuevaFactura);
                if (result)
                {
                    return Ok(new { mensaje = "factura actualizado con éxito", Factura = nuevaFactura });
                }
                else
                {
                    return Problem(detail: "No se ha podido actualizar la factura", statusCode: 500);
                }
            }
            catch (Exception)
            {

                return Problem(detail: "Error interno al actualizar la factura", statusCode: 500);
            }
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _facturaServicio.DeleteFactura(id);
                if (result)
                    return Ok(new { mensaje = "Factura eliminada con éxito" });
                else
                    return Problem(detail:"No se pudo eliminar la factura", statusCode: 500);
            }
            catch (Exception)
            {
                return Problem("Error interno al eliminar la factura", statusCode: 500);
            }
        }
    }
}
