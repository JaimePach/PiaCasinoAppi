using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiaCasinoAppi.Entidades;
using PiaCasinoAppi.DTOs;

namespace PiaCasinoAppi.Controllers
{

    [ApiController]
    [Route("Participante")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class ParticipanteController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public ParticipanteController(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            this.dbContext = context;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        [HttpPost] //Inscribir un Participante
        public async Task<ActionResult> Post(CreacionParticipanteDTO creacionParticipante)
        {
            

            var vato = mapper.Map<Participante>(creacionParticipante);
            dbContext.Add(vato);
            await dbContext.SaveChangesAsync();

            var participanteDTO = mapper.Map<GetParticipantesDTO>(vato);

            return CreatedAtRoute("ObtenerParticipante", new { id = vato.Id }, participanteDTO);


        }



    }
}
