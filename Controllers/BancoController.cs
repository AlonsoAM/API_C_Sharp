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
    public class BancoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<MensajeModel<BancoModel>>> Get()
        {
            var funcion = new BancoData();
            var mensaje = await funcion.ListarBancos();
            return mensaje;
        }

    }
}