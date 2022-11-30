namespace PiaCasinoAppi.Entidades
{
    public class Premio
    {
       public int Id { get; set; }

       public string Objeto { get; set; }

       public int Orden { get; set; }

       public int BoletoID { get; set; }

        public int RifaID { get; set; }
       public Boleto Boleto { get; set; }
        public Rifa Rifa { get; set; }


    }
}
