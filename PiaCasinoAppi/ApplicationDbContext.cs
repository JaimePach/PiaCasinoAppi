using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PiaCasinoAppi.Entidades;

namespace PiaCasinoAppi
{
    public class ApplicationDbContext: IdentityDbContext
     {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
          }

       public DbSet<Boleto> Boletos { get; set; }
       public DbSet<Participante> Participantes { get; set; }
       public DbSet<Premio> Premios { get; set; }
       public DbSet<Rifa> Rifas { get; set; }
       public DbSet<ParticipanteRifa> ParticipanteRifa { get; set; }

    }
}
