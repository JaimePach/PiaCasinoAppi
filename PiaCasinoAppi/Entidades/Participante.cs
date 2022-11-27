namespace PiaCasinoAppi.Entidades
{
    public class Participante
    {
        public int Id { get; set;}

        public string Nombre { get; set;}

        public string Email { get; set; }

 
        public List<ParticipanteRifa> ParticipanteRifa { get; set;}

        public List<Boleto> Boleto { get; set; }

    }
}
