using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasObjetos
{
    public class Itens
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdVenda { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }
    }
}