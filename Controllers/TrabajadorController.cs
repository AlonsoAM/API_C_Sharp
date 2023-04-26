using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using novaltyAPI.Data;
using novaltyAPI.Model;

namespace novaltyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("Politica")]
    public class TrabajadorController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<MensajeModel<TrabajadorModel>>> Get()
        {
            var funcion = new TrabajadorData();
            var mensaje = await funcion.ListarTrabajadores();
            return mensaje;
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<MensajeModel<TrabajadorModel>>> GetById(int id)
        {
            var funcion = new TrabajadorData();
            var mensaje = await funcion.VerTrabajador(id);
            return mensaje;
        }

        [HttpGet("ByFormPago/{id_form_pago}")]
        public async Task<ActionResult<MensajeModel<TrabajadorModel>>> GetByFormPay(int id_form_pago)
        {
            var funcion = new TrabajadorData();
            var mensaje = await funcion.ListarTrabajadorePorFormaDePago(id_form_pago);
            return mensaje;
        }

        [HttpPost]
        public async Task<ActionResult<SimpleRespModel>> Post([FromBody] ParamsInsertarTrabajadorModel parametros)
        {
            var funcion = new TrabajadorData();
            var mensaje = await funcion.InsertarTrabajador(parametros);
            return mensaje;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SimpleRespModel>> Put(int id, [FromBody] ParamsInsertarTrabajadorModel parametros)
        {
            var funcion = new TrabajadorData();
            var mensaje = await funcion.ActualizarTrabajador(parametros, id);
            return mensaje;
        }
    }
}