﻿namespace PiaCasinoAppi.Entidades
{
    public class Boleto
    {
        public int Id { get; set; }

       
        public int RifaID {get; set;}


        public int ParticipanteID { get; set; }

        public int NumeroLoteria { get; set; }

        public Rifa Rifa { get; set; }

        public Participante Participante { get; set; }

       

      
        
    }
}
