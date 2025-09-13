using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services.Implementacion;
using proyecto_Practica01_.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        IArticuloService _articuloService;
        public ArticulosController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        // GET: api/<ArticulosControler>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = _articuloService.GetAll();
                if (lst == null)
                {
                    return Problem(detail: "no hay articulos", statusCode: 500);
                }
                return Ok(new { mensaje = "Artículos obtenidos con éxito", datos = lst });
            }
            catch (Exception)
            {
                return Problem(detail: "Error al acceder a datos", statusCode: 500);
            }
        }

        // GET api/<ArticulosControler>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Articulo? art = _articuloService.GetById(id);
                if (art == null)
                {
                    return BadRequest(new { mensaje = "articulo no encontrado" });
                }
                return Ok(new { mensaje = "Artículo obtenidos con éxito", Articulo = art });
            }
            catch (Exception)
            {
                return Problem(detail: "Error interno al acceder al artículo", statusCode: 500);
            }
        }

        // POST api/<ArticulosControler>
        [HttpPost]
        public IActionResult Post(Articulo articulo)
        {
            if (articulo == null)
                return BadRequest(new { mensaje = "El artículo no puede ser nulo" });
            try
            {
                bool resutl = _articuloService.Create(articulo);
                if (resutl)
                {
                    return Ok(new { mensaje = "Artículo creado con éxito", Articulo = articulo });
                }
                else
                {
                    return Problem(detail: "No se ha podido guardar el artículo", statusCode: 500);
                }
            }
            catch (Exception ex)
            {
                return Problem(detail: "Error interno al guardar el artículo", statusCode: 500);
            }
        }

        // PUT api/<ArticulosControler>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulo articulo)
        {
            if (articulo == null)
                return BadRequest(new { mensaje = "El artículo no puede ser nulo" });
            try
            {
                articulo.Id_articulo = id;
                bool result = _articuloService.Create(articulo);
                if (result)
                {
                    return Ok(new { mensaje = "Artículo actualizado con éxito", Articulo = articulo });
                }
                else
                {
                    return Problem(detail: "No se ha podido actualizar el artículo", statusCode: 500);
                }
            }
            catch (Exception)
            {

                return Problem(detail: "Error interno al actualizar el artículo", statusCode: 500);
            }
        }

        // DELETE api/<ArticulosControler>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _articuloService.Delete(id);
                if (result)
                {
                    return Ok(new { mensaje = "Artículo eliminado con éxito"});
                }
                else
                {
                    return Problem(detail: "no se ha podido eliminar el artículo", statusCode: 500);
                }
            }
            catch (Exception ex)
            {
                return Problem(detail: "Error interno al eliminar el artículo", statusCode: 500);
            }
        }
    }
}
