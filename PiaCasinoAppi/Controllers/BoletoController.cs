using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PiaCasinoAppi.Entidades;
using PiaCasinoAppi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace PiaCasinoAppi.Controllers
{
    [ApiController]
    [Route("Boletos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class BoletoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        public BoletoController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet("{boleto}")]//Boletos Disponibles
        [AllowAnonymous]
        public async Task<ActionResult<List<GetBoletosDTO>>> Get([FromRoute] int id)
        {
            var boletos = await dbContext.Boletos.Where(boletoBD => boletoBD.RifaID == id).ToListAsync();

            return mapper.Map<List<GetBoletosDTO>>(boletos);

        }


        [HttpPost] // Crear Boleto sin participante asociado y sin repetir numero de loteria

        public async Task<ActionResult> Post(CreacionBoletoDTO creacionBoleto)
        {
            var existRifa = await dbContext.Rifas.AnyAsync(x => x.Id == creacionBoleto.RifaID);//Aqui verifica si existe la rifa 
            var existnumero = await dbContext.Boletos.AnyAsync(y => y.NumeroLoteria == creacionBoleto.NumeroLoteria); //Aqui se verifica si el numero de loteria ya ah sido usado

            if (!existRifa)//si no existe se para
            {
                return NotFound();

            }
            if(!existnumero)
            {
                return NotFound();

            }

            var boletito = mapper.Map<Boleto>(creacionBoleto);
            dbContext.Add(boletito);
            await dbContext.SaveChangesAsync();

            var boletoDTO = mapper.Map<GetBoletosDTO>(boletito);

            return CreatedAtRoute("ObtenerParticipante", new { id = boletito.Id }, boletoDTO);


        }

        
    }
}
