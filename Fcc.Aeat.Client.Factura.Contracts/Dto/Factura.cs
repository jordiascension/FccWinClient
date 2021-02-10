﻿namespace Fcc.Aeat.Client.Factura.Contracts.Dto
{
    public class Factura
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Nif { get; set; }
        public decimal Importe { get; set; }
        public decimal Base { get; set; }
        public byte Iva { get; set; }
        public string Fecha { get; set; }
    }
}
