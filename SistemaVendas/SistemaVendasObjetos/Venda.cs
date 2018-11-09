using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasObjetos
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
        public int IdCliente { get; set; }
    }   
}