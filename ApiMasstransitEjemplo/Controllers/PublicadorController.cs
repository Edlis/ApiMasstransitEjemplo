using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMasstransitEjemplo.Consumidor;
using MassTransit;
using Mensajes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMasstransitEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicadorController : ControllerBase
    {
        readonly IBus _bus;
        public PublicadorController(IBus bus) {
            _bus = bus;
        }

        // POST api/<PublicadorController>
        [HttpPost("send")]
        public async Task<ActionResult> PostAsync(Correo c)
        {
            try
            {
                //si el bus no se definó consumidor asociado al mensaje no existe el binding por lo que no sabe a que cola enviarse

                
                //Uri uri = new Uri("rabbitmq://localhost/Consumidor");
                //var endPoint = await _bus.GetSendEndpoint(uri);
                //await endPoint.Send(c);                
                await _bus.Publish(c);
                return Ok("ok");
            }
            catch (Exception ex)
            {

                return BadRequest();
            }            
        }        
    }
}
