﻿using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost] //Crear Premio sin ganador
        public async Task<ActionResult> Post(CreacionPremioDTO creacionpremio)
        {


            var premio = mapper.Map<Premio>(creacionpremio);
            dbContext.Add(premio);
            await dbContext.SaveChangesAsync();

            var premioDTO = mapper.Map<GetPremioDTO>(premio);

            return CreatedAtRoute("ObtenerPremio", new { id = premio.Id }, premioDTO);


        }
    }
}
