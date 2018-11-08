using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasObjetos
{
    public class Cliente
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
        public String CPF { get; set; }

        public Cliente(String nome, String telefone, String email, String cpf)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.CPF = cpf;
        }
    }
}