using Microsoft.AspNetCore.Mvc;
using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services.Implementacion;
using proyecto_Practica01_.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosControler : ControllerBase
    {
        IArticuloService _articuloService;
        public ArticulosControler(IArticuloService articuloService)
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
                    return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "error al acceder a datos" });
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "articulos obtenidos con exito",lst });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "error al acceder a datos" });
            }
        }

        // GET api/<ArticulosControler>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_articuloService.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "error al acceder a datos" });
            }
        }

        // POST api/<ArticulosControler>
        [HttpPost]
        public IActionResult Post(Articulo articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest();
                }
                bool resutl = _articuloService.Create(articulo);
                if (resutl)
                {
                    return StatusCode(StatusCodes.Status201Created, $"articulo {articulo.Id_articulo} creado con exito");
                }
                else
                {
                    return StatusCode(500, "no se ha podido gaurar el articulo");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "no se ha podido gaurar el articulo");
            }
        }

        // PUT api/<ArticulosControler>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulo articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest();
                }
                articulo.Id_articulo = id;
                bool result = _articuloService.Create(articulo);
                if (result)
                {
                    return StatusCode(StatusCodes.Status201Created, new { mensaje = $"articulo actualizado con exito { articulo }"  });
                }
                else
                {
                    return StatusCode(500, "no se ha podido actualizar el articulo");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "no se ha podido actualizar el articulo");
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
                    return StatusCode(StatusCodes.Status200OK, "articulo eliminad con exito");
                }
                else
                {
                    return StatusCode(500, "no se ha podido eliminar el articulo");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "no se ha podido eliminar el articulo");
            }
        }
    }
}
