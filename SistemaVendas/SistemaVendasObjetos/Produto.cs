using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasObjetos
{
    public class Produto
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public float Valor { get; set; }
        public int IdFornecedor { get; set; }

        public Produto(string nome, float valor, int idFornecedor)
        {
            Nome = nome;
            Valor = valor;
            this.IdFornecedor = idFornecedor;
        }
    }
}