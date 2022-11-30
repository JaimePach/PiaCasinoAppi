using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiaCasinoAppi.DTOs;
using PiaCasinoAppi.Entidades;
using System.Security.Cryptography.X509Certificates;

namespace PiaCasinoAppi.Controllers
{
    [ApiController]
    [Route("Rifa")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
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



        [HttpPost]   //Crear una Rifa
        public async Task<ActionResult> Post(CreacionRifaDTO creacionRifa)
        {
            var existeRifa = await dbContext.Rifas.AnyAsync(x => x.NombreRifa == creacionRifa.NombreRifa);

            if (existeRifa)
            {
                return BadRequest($"Ya existe esta rifa con el nombre {creacionRifa.NombreRifa}");
            }

            var Rifita = mapper.Map<Rifa>(creacionRifa);
            dbContext.Add(Rifita);
            await dbContext.SaveChangesAsync();

            var RifitaDTO = mapper.Map<GetRifaDTO>(Rifita);

            return CreatedAtRoute("ObtenerRifa", new { id = Rifita.Id }, RifitaDTO);






        }
    }
}
