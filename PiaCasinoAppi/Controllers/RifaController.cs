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
    [Route("Rifa")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RifaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public RifaController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet("Rifas")]//Mostrar todas las rifas
        public async Task<ActionResult<List<GetRifaDTO>>> Get()
        {
            var Rifas = await dbContext.Rifas.ToListAsync();
            return mapper.Map<List<GetRifaDTO>>(Rifas);
        }

     
        
        [HttpPost("Inscripcion")]//Inscribir participante a rifa

        public async Task<ActionResult> Post(CrearParticipanteRifa participanterifa)
        {
            var existrifa = await dbContext.Rifas.AnyAsync(x => x.Id == participanterifa.RifaID);
            var existparticipante = await dbContext.Participantes.AnyAsync(y => y.Id == participanterifa.ParticipanteID);

            if (existrifa) //entra si existe rifa
            {
                if (existparticipante) //entra si existe le participante
                {
                    var rifaparticipante = mapper.Map<ParticipanteRifa>(participanterifa);
                    dbContext.Add(rifaparticipante);
                    await dbContext.SaveChangesAsync();

                    var Inscripcion = mapper.Map<GetParticipanteRifa>(rifaparticipante);
                    return CreatedAtRoute("verInscripcion", new { id = rifaparticipante.Id }, Inscripcion);

                }

                return BadRequest("No existe el participante");
            }

            return BadRequest("No existe la rifa");
        }

        [HttpPut("{id:int}")] //Participante compra boleto

        public async Task<ActionResult> Put(ComprarBoletoDTO comprarboletodto, int id)
        {
            var existBoleto = await dbContext.Boletos.AnyAsync(y => y.Id == id);

            var existparticipante = await dbContext.Participantes.AnyAsync(x => x.Id == comprarboletodto.RifaID);

            if (!existparticipante)//checar si existe un participante por id
            {

                return BadRequest("El participante no existe");

            }
            if (!existBoleto)
            {
                return BadRequest("No existe el boleto a comprar");
            }

            var Compra = mapper.Map<Boleto>(comprarboletodto);
            Compra.Id = id;

            dbContext.Update(Compra);
            await dbContext.SaveChangesAsync();
            return NoContent();

        }


    }
}
