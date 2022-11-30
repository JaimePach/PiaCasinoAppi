namespace PiaCasinoAppi.Entidades
{
    public class ParticipanteRifa
    {
      
        public int Id { get; set; }

        public int RifaID { get; set; }

        public int ParticipanteID { get; set; }

        public Rifa Rifa { get; set; }

        public Participante Participante { get; set; }

      }
}
