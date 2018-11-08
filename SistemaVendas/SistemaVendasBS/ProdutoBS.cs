using SistemaVendasDAO;
using SistemaVendasObjetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVendasBS
{
    public class ProdutoBS
    {
        public static Produto Create(Produto produto)
        {
            return new ProdutoDAO().Create(produto);
        }
    }
}