using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasObjetos
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String NomeEmpresa { get; set; }
        public String Telefone { get; set; }

        public Fornecedor(String nome, String nomeEmpresa,String telefone)
        {
            Nome = nome;
            NomeEmpresa = nomeEmpresa;
            Telefone = telefone;
        }
    }
}