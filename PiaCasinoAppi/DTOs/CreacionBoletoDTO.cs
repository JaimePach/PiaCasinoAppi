﻿using PiaCasinoAppi.Entidades;

namespace PiaCasinoAppi.DTOs
{
    public class CreacionBoletoDTO
    {
        public int RifaID { get; set; }

        public int NumeroLoteria { get; set; }

        public Rifa Rifa { get; set; }
    }
}
