using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiaCasinoAppi.DTOs;
using PiaCasinoAppi.Entidades;

namespace PiaCasinoAppi.Controllers
{
    [ApiController]
    [Route("Premio")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class PremioController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public PremioController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }


        [HttpGet("Premios")]//Mostrar todas los premios
        [AllowAnonymous]
        public async Task<ActionResult<List<GetPremioDTO>>> Get()
        {
            var premio = await dbContext.Premios.ToListAsync();
            return mapper.Map<List<GetPremioDTO>>(premio);
        }

        [HttpPost] //Crear Premio sin ganador
        public async Task<ActionResult> Post(CreacionPremioDTO creacionpremio)
        {
            var existrifa = await dbContext.Rifas.AnyAsync(x => x.Id == creacionpremio.RifaID);

            if (!existrifa)
            {
                return NotFound();
            }

            var premio = mapper.Map<Premio>(creacionpremio);
            dbContext.Add(premio);
            await dbContext.SaveChangesAsync();

            var premioDTO = mapper.Map<GetPremioDTO>(premio);

            return CreatedAtRoute("ObtenerPremio", new { id = premio.Id }, premioDTO);


        }

        [HttpPut("{id:int}")] //Colocar Boleto ganador a premio
        public async Task<ActionResult> Put(int id, AsignarpremioDTO asignarpremio) //Falta dar aleatoriedad
        {
            var existpremio = await dbContext.Premios.AnyAsync(x => x.Id == id);
            if (!existpremio)
            {
                return BadRequest("El premio no existe");
            }

            var ganador = mapper.Map<Premio>(asignarpremio);
            ganador.Id = id;

            dbContext.Update(ganador);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }




    }
}
