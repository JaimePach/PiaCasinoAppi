using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PiaCasinoAppi.Entidades;
using PiaCasinoAppi.DTOs;

namespace PiaCasinoAppi.Controllers
{
    [ApiController]
    [Route("Boletos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class BoletoController: ControllerBase
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

        [HttpPost] // Crear Boleto sin participante asociado

        public async Task<ActionResult> Post(CreacionBoletoDTO creacionBoleto)
        {


            var boletito = mapper.Map<Boleto>(creacionBoleto);
            dbContext.Add(boletito);
            await dbContext.SaveChangesAsync();

            var participanteDTO = mapper.Map <GetBoletosDTO>(boletito);

            return CreatedAtRoute("ObtenerParticipante", new { id = boletito.Id }, participanteDTO);


        }

        [HttpPut] // Participante compra boleto

        public async Task<ActionResult> Put(CreacionBoletoDTO creacionboleto)
        {


           
        }

    }
}
